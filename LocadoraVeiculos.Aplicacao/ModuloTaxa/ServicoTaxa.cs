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

        private RepositorioTaxa repositorio;
        private ValidadorTaxa validador;

        public ServicoTaxa(RepositorioTaxa repositorio)
        {
            this.repositorio = repositorio;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorio.Inserir(taxa);
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
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorio.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaNome} editada com sucesso", taxa.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxaNome} - {Motivo}",
                        taxa.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
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

            var taxaEncontrada = repositorio.SelecionarTaxaPorNome(taxa.Nome);

            return taxaEncontrada != null &&
                   taxaEncontrada.Nome == taxa.Nome &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
