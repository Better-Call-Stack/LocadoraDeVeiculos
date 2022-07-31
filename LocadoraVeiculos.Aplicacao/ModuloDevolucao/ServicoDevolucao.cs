using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao
    {
        private RepositorioDevolucaoOrm repositorioDevolucao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoDevolucao(RepositorioDevolucaoOrm repositorioDevolucao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioDevolucao = repositorioDevolucao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Devolucao> Inserir(Devolucao devolucao)
        {
            Log.Logger.Debug("Inserindo devolução {@dv}", devolucao);

            Result resultadoValidacao = Validar(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir devolução {DevolucaoId} - {Motivo}: ",
                        devolucao.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioDevolucao.Inserir(devolucao);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Devolução {DevolucaoId} inserido", devolucao.Id);

                return Result.Ok(devolucao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar iserir a devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> Editar(Devolucao devolucao)
        {
            Log.Logger.Debug("Editando Devolução... {@dv}", devolucao);

            var resultadoValidacao = Validar(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma devolução {DevolucaoId} - {Motivo}",
                       devolucao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Editar(devolucao);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Devolução {DevolucaoId} editado", devolucao.Id);

                return Result.Ok(devolucao);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Devolucao devolucao)
        {
            Log.Logger.Debug("Excluindo Devolução {@pc}", devolucao);

            try
            {
                repositorioDevolucao.Excluir(devolucao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Devolução {DevolucaoId} excluído", devolucao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir uma devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Devolucao>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar uma devolução...");

            try
            {
                var devolucoes = repositorioDevolucao.SelecionarTodos();

                Log.Logger.Information("Devoluções selecionadas com sucesso");

                return Result.Ok(devolucoes);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todas as devoluções";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar uma devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", id);

                return Result.Fail(msgErro);
            }
        }
        private Result Validar(Devolucao devolucao)
        {
            var validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                errors.Add(new Error(item.ErrorMessage));
            }

            if (IdDuplicado(devolucao))
                errors.Add(new Error("Id Duplicado"));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }

        private bool IdDuplicado(Devolucao devolucao)
        {
            var devolucaoEncontrada = new Devolucao();

            if (devolucao.Locacao != null)
                devolucaoEncontrada = repositorioDevolucao.SelecionarPorId(devolucao.Locacao.Id);

            return devolucaoEncontrada != null &&
                   devolucaoEncontrada.Id != devolucao.Id;
        }
    }
}
