using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private RepositorioCondutor repositorioCondutor;
        private ValidadorCondutor validadorCondutor;

        public ServicoCondutor(RepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", condutor);

            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Debug("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {

            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);

            var resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Debug("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@c}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O condutor {condutor.Nome} está relacionado com um condutor e não pode ser excluído";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result<Condutor> ValidarCondutor(Condutor condutor)
        {

            validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (CpfDuplicado(condutor))
                erros.Add(new Error("CPF Duplicado"));

            if (CnhDuplicada(condutor))
                erros.Add(new Error("CNH Duplicada"));


            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.Id != condutor.Id;
        }

        private bool CnhDuplicada(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return condutorEncontrado != null &&
                   condutorEncontrado.CNH == condutor.CNH &&
                   condutorEncontrado.Id != condutor.Id;
        }
    }
}
