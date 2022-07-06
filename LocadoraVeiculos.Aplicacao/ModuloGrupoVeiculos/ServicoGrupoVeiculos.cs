using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoDeVeiculos grupoDeVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos grupoDeVeiculos)
        {
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Editar(grupoDeVeiculos);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculos grupoDeVeiculos)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupoDeVeiculos);

            if (NomeDuplicado(grupoDeVeiculos))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoDeVeiculos grupoDeVeiculos)
        {
            var grupoVeiculosEncontrado = repositorioGrupoVeiculos.SelecionarGrupoVeiculosPorNome(grupoDeVeiculos.Nome);

            return grupoVeiculosEncontrado != null &&
                   grupoVeiculosEncontrado.Nome == grupoDeVeiculos.Nome &&
                   grupoVeiculosEncontrado.Id != grupoDeVeiculos.Id;
        }
    }
}
