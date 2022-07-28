using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
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
        private RepositorioTaxaOrm repositorioTaxa;
        private IContextoPersistencia contextoPersistencia;

        public ServicoTaxa(RepositorioTaxaOrm repositorioTaxa, IContextoPersistencia contexto)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.contextoPersistencia = contexto;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            var resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir uma Taxa {TaxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Taxa {TaxaId} inserido com sucesso", taxa.Id);

                return Result.Ok(taxa);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@c}", taxa);

            var resultadoValidacao = ValidarTaxa(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Taxa {TaxaId} editada com sucesso", taxa.Id);

                return Result.Ok(taxa);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@c}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Taxa {TaxaId} excluída com sucesso", taxa.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"A taxa {taxa.Nome} está relacionada com um condutor e não pode ser excluída";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a taxa";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }


        public Result<Taxa> ValidarTaxa(Taxa taxa)
        {
            var validadorTaxa = new ValidadorTaxa();

            var resultadoValidacao = validadorTaxa.Validate(taxa);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(taxa))
            erros.Add(new Error("Nome Duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
