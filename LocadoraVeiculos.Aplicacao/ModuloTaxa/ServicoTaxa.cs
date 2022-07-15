using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {

        private RepositorioTaxa repositorioTaxa;
        private ValidadorTaxa validador;

        public ServicoTaxa(RepositorioTaxa repositorio)
        {
            this.repositorioTaxa = repositorio;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaId} inserida com sucesso", taxa.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir uma Taxa {TaxaId} - {Motivo}",
                        taxa.Id, erro.ErrorMessage);
                }

            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {

            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaId} editada com sucesso", taxa.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxaId} - {Motivo}",
                        taxa.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir Taxa... {@t}", taxa);

            repositorioTaxa.Excluir(taxa);

            Log.Logger.Debug("Taxa com Id = '{TaxaId}' excluído", taxa.Id);

            return new ValidationResult();
        }


        public ValidationResult Validar(Taxa taxa)
        {
            validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("NOME", "Nome Duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {

            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorNome(taxa.Nome);

            return taxaEncontrada != null &&
                   taxaEncontrada.Nome == taxa.Nome &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
