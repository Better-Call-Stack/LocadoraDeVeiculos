using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private RepositorioVeiculoOrm repositorioVeiculo;
        private IContextoPersistencia contextoPersistencia;


        public ServicoVeiculo(RepositorioVeiculoOrm repositorioVeiculo, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veiculo... {@v}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Veiculo {VeiculoId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Inserir(veiculo);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veiculo {VeiculoId} inserido com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Veiculo... {@f}", veiculo);

            var resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Veiculo {FuncionarioId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Editar(veiculo);

                contextoPersistencia.GravarDados();
                Log.Logger.Debug("Veículo {VeiculoId} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veiculo... {@f}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veiculo {VeiculoId} excluído com sucesso", veiculo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    string msgErroDelete = "";

                    if (ex != null && ex.InnerException.Message.Contains("Locacao"))
                        msgErroDelete = $"O veículo {veiculo.Modelo} está relacionado com uma locação e não pode ser excluído";

                    Log.Logger.Error(ex, msgErroDelete + "{VeiculoId}", veiculo.Id);

                    return Result.Fail(msgErroDelete);

                }
                string msgErro = "Falha no sistema ao tentar excluir o veículo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os veículos.";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o veículo.";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarVeiculo(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)             
                erros.Add(new Error(item.ErrorMessage));

            if (PlacaDuplicada(veiculo))
                erros.Add(new Error("Placa duplicada."));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
