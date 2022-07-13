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
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.ValorPorDia_PlanoDiario);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.ValorKmRodado_PlanoDiario);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.ValorPorDia_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.ValorKmRodado_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.KmLivreIncluso_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} inserido", planoDeCobranca.ValorPorDia_PlanoKmLivre);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Plano de Cobrança {PlanoDeCobrancaNome} - {Motivo}: ",planoDeCobranca.ValorPorDia_PlanoDiario, 
                        planoDeCobranca.ValorKmRodado_PlanoDiario, planoDeCobranca.ValorPorDia_PlanoKmControlado, planoDeCobranca.ValorKmRodado_PlanoKmControlado,
                        planoDeCobranca.KmLivreIncluso_PlanoKmControlado, planoDeCobranca.ValorPorDia_PlanoKmLivre, erro.ErrorMessage);
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
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.ValorPorDia_PlanoDiario);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.ValorKmRodado_PlanoDiario);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.ValorPorDia_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.ValorKmRodado_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.KmLivreIncluso_PlanoKmControlado);
                Log.Logger.Debug("Plano de Cobrança {PlanoDeCobrancaNome} editado", planoDeCobranca.ValorPorDia_PlanoKmLivre);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Plano de Cobrança {PlanoDeCobrancaNome} - {Motivo}: ", planoDeCobranca.ValorPorDia_PlanoDiario,
                        planoDeCobranca.ValorKmRodado_PlanoDiario, planoDeCobranca.ValorPorDia_PlanoKmControlado, planoDeCobranca.ValorKmRodado_PlanoKmControlado,
                        planoDeCobranca.KmLivreIncluso_PlanoKmControlado, planoDeCobranca.ValorPorDia_PlanoKmLivre, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
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

        private bool IdDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var planoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarGrupoDeVeiculosDoPlanoDeCobrancaPorId(planoDeCobranca.GrupoDeVeiculos.Id);

            return planoDeCobrancaEncontrado != null &&
                   planoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}

