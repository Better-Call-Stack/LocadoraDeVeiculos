using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private RepositorioPlanoCobrancaOrm repositorioPlanoDeCobranca;
        private IContextoPersistencia contextoPersistencia;

        public ServicoPlanoDeCobranca(RepositorioPlanoCobrancaOrm repositorioPlanoDeCobranca, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Inserindo Plano de Cobrança {@pc}", planoDeCobranca);

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}: ",
                        planoDeCobranca.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} inserido", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar iserir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Editando Plano de Cobrança... {@pc}", planoDeCobranca);

            var resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} editado", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Excluindo  Plano de Cobranca {@pc}", planoDeCobranca);

            try
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano de Cobranca {PlanoDeCobrancaId} excluído", planoDeCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    string msgErroDelete = "";

                    if (ex != null && ex.InnerException.Message.Contains("Veiculo"))
                        msgErroDelete = $"O plano de cobrança do grupo de veiculos {planoDeCobranca.GrupoDeVeiculos} está relacionado com um veículo e não pode ser excluído";

                    Log.Logger.Error(ex, msgErroDelete + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                    return Result.Fail(msgErroDelete);

                }
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar planos de cobrança...");

            try
            {
                var planoDeCobrancas = repositorioPlanoDeCobranca.SelecionarTodos(incluirGrupoVeiculos: true);

                Log.Logger.Information("Planos de Cobrança selecionados com sucesso");

                return Result.Ok(planoDeCobrancas);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os planos de cobrança";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(PlanoDeCobranca planoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(planoDeCobranca);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                errors.Add(new Error(item.ErrorMessage));
            }

            if (IdDuplicado(planoDeCobranca))
                errors.Add(new Error("Id Duplicado"));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }

        private bool IdDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var planoDeCobrancaEncontrado = new PlanoDeCobranca();

            if (planoDeCobranca.GrupoDeVeiculos != null)
                planoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.GrupoDeVeiculos.Id);

            return planoDeCobrancaEncontrado != null &&
                   planoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}

