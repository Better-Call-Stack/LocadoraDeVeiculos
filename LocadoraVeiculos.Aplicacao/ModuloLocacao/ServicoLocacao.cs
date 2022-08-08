using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloOrm;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private RepositorioVeiculoOrm repositorioVeiculo;
        private RepositorioLocacaoOrm repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoLocacao(RepositorioLocacaoOrm repositorioLocacao, RepositorioVeiculoOrm repositorioVeiculo, IContextoPersistencia contexto)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistencia = contexto;
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public Result<Locacao> Inserir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando inserir locacao... {@c}", locacao);

            var resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Locacao {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(locacao);

                locacao.Veiculo.StatusVeiculo = LocadoraDeVeiculos.Dominio.ModuloVeiculo.StatusVeiculoEnum.Alugado;
                repositorioVeiculo.Editar(locacao.Veiculo);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Locacao {LocacaoId} inserido com sucesso", locacao.Id);

                return Result.Ok(locacao);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<Locacao> Editar(Locacao locacao)
        {
            Log.Logger.Debug("Tentando editar locacao... {@c}", locacao);

            var resultadoValidacao = ValidarLocacao(locacao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Locacao {LocacaoId} - {Motivo}",
                       locacao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Editar(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Locacao {LocacaoId} editada com sucesso", locacao.Id);

                return Result.Ok(locacao);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao locacao)
        {
            Log.Logger.Debug("Tentando excluir locação... {@l}", locacao);

            try
            {
                repositorioLocacao.Excluir(locacao);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Locação {LocacaoId} excluída com sucesso", locacao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", locacao.Id);

                return Result.Fail(msgErro);
            }
        }

        private Result<Locacao> ValidarLocacao(Locacao locacao)
        {
            var validadorLocacao = new ValidadorLocacao();

            var resultadoValidacao = new ValidationResult();
            List<Error> erros = new List<Error>();


            if (locacao.Condutor != null) 
                resultadoValidacao = validadorLocacao.Validate(locacao);
            else
            {
               erros.Add(new Error("Cliente não possui nenhum condutor"));
            }

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgError = "Falha no sistema ao tentar selecionar todas as locações";

                Log.Logger.Error(ex, msgError);

                return Result.Fail(msgError);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", id);

                return Result.Fail(msgErro);
            }
        }
    }
}
