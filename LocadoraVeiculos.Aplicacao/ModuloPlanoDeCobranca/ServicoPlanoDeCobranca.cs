using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
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
            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);

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

