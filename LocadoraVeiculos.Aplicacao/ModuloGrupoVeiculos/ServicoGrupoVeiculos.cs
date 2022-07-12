using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private RepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(RepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Inserindo Grupo de Veiculos {@gv}", grupoDeVeiculos);

            ValidationResult resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);
                Log.Logger.Debug("Grupo de Veiculos {GrupoDeVeiculosNome} inserido", grupoDeVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Grupo de Veiculos {GrupoDeVeiculosNome} - {Motivo}: ",
                        grupoDeVeiculos.Nome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Editando Grupo de Veiculos {@pc}", grupoDeVeiculos);

            ValidationResult resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Editar(grupoDeVeiculos);
                Log.Logger.Debug("Grupo de Veiculos {GrupoDeVeiculosNome} editado", grupoDeVeiculos.Nome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Grupo de Veiculos {GrupoDeVeiculosNome} - {Motivo}: ",
                        grupoDeVeiculos.Nome, erro.ErrorMessage);
                }
            }
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
