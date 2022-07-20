using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
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
        private RepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
        {
            /*Log.Logger.Debug("Inserindo Plano de Cobrança {@pc}", planoDeCobranca);

            var resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} inserido", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar iserir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }*/
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
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} inserido", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar iserir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
            /*if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} inserido", planoDeCobranca.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}: ", 
                        planoDeCobranca.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;*/
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
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} editado", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
            /*Log.Logger.Debug("Editando Plano de Cobrança {@pc}", planoDeCobranca);

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}: ",
                        planoDeCobranca.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} editado", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
            return Result.Ok();*/
        }
        public Result Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Excluindo  Plano de Cobranca {@pc}", planoDeCobranca);

            try
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

                Log.Logger.Information("Plano de Cobranca {PlanoDeCobrancaId} excluído", planoDeCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano de cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
            /*Log.Logger.Debug("Excluindo  Plano de Cobranca {@pc}", planoDeCobranca);

            try
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobranca);
                Log.Logger.Debug("Plano de Cobranca {PlanoDeCobrancaId} excluído", planoDeCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano de cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
            return Result.Ok();
            /* Log.Logger.Debug("Tentando excluir Plano de Cobranca... {@pc}", planoDeCobranca);

             repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

             Log.Logger.Debug("Plano de Cobranca com Id = '{PlanoDeCobrancaId}' excluído", planoDeCobranca.Id);

             return new ValidationResult();*/
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
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

            /*var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(planoDeCobranca);

            if (planoDeCobranca.GrupoDeVeiculos != null)    
                if (IdDuplicado(planoDeCobranca))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Erro", "Grupo de veiculos já possue plano de cobrança"));

            return resultadoValidacao;*/
        }

        private bool IdDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var planoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarGrupoDeVeiculosDoPlanoDeCobrancaPorId(planoDeCobranca.GrupoDeVeiculos.Id);

            return planoDeCobrancaEncontrado != null &&
                   planoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}

