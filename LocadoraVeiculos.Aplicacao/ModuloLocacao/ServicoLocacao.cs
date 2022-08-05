using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloRelatorio;
using LocadoraDeVeiculos.Infra.Orm.ModuloOrm;
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

        private RepositorioLocacaoOrm repositorioLocacao;
        private IContextoPersistencia contextoPersistencia;
        private IGeradorRelatorio geradorRelatorio;

        public ServicoLocacao(RepositorioLocacaoOrm repositorioLocacao, IContextoPersistencia contexto, IGeradorRelatorio geradorRelatorio)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contextoPersistencia = contexto;
            this.geradorRelatorio = geradorRelatorio;
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

                contextoPersistencia.GravarDados();

                geradorRelatorio.GerarRelatorioPdf();

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

            var resultadoValidacao = validadorLocacao.Validate(locacao);

            List<Error> erros = new List<Error>();
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
