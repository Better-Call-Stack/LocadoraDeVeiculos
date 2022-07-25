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

        public ValidationResult Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Inserindo Plano de Cobrança {@pc}", planoDeCobranca);

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
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

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Editando Plano de Cobrança {@pc}", planoDeCobranca);

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaId} editado", planoDeCobranca.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Plano de Cobrança {PlanoDeCobrancaId} - {Motivo}: ", planoDeCobranca.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }
        public ValidationResult Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando excluir Plano de Cobranca... {@pc}", planoDeCobranca);

            repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

            Log.Logger.Debug("Plano de Cobranca com Id = '{PlanoDeCobrancaId}' excluído", planoDeCobranca.Id);

            return new ValidationResult();
        }

        private ValidationResult Validar(PlanoDeCobranca planoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(planoDeCobranca);

            if (planoDeCobranca.GrupoDeVeiculos != null)    
                if (IdDuplicado(planoDeCobranca))
                    resultadoValidacao.Errors.Add(new ValidationFailure("Erro", "Grupo de veiculos já possue plano de cobrança"));

            return resultadoValidacao;
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Planos de Cobrança.";

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
                string msgErro = "Falha no sistema ao tentar selecionar o plano de cobrança.";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private bool IdDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var planoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarGrupoDeVeiculosDoPlanoDeCobrancaPorId(planoDeCobranca.GrupoDeVeiculos.Id);

            return planoDeCobrancaEncontrado != null &&
                   planoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}

