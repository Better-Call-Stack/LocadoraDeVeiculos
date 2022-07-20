using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos
    {
        private RepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ServicoGrupoVeiculos(RepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public Result<GrupoDeVeiculos> Inserir(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Inserindo Grupo de Veiculos {@gv}", grupoDeVeiculos);

            Result resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao inserir Grupo de Veiculos {GrupoDeVeiculosId} - {Motivo}: ",
                        grupoDeVeiculos.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);
                Log.Logger.Debug("Grupo de Veiculos {GrupoDeVeiculosId} inserido", grupoDeVeiculos.Id);

                return Result.Ok(grupoDeVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar iserir o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculos> Editar(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Editando Grupo de Veiculos {@gv}", grupoDeVeiculos);

            Result resultadoValidacao = Validar(grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao editar Grupo de Veiculos {GrupoDeVeiculosId} - {Motivo}: ",
                        grupoDeVeiculos.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioGrupoVeiculos.Editar(grupoDeVeiculos);
                Log.Logger.Debug("Grupo de Veiculos {GrupoDeVeiculosId} editado", grupoDeVeiculos.Id);

                return Result.Ok(grupoDeVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
            return Result.Ok();
        }

        public Result Excluir(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Excluindo Grupo de Veiculos {@gv}", grupoDeVeiculos);

            try
            {
                repositorioGrupoVeiculos.Excluir(grupoDeVeiculos);
                Log.Logger.Debug("Grupo de Veiculos {GrupoDeVeiculosId} excluído", grupoDeVeiculos.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsseRegistroException ex)
            {
                string msgErro = $"Grupo de veículos {grupoDeVeiculos.Nome} está relacionado com " +
                    $"plano de cobrança e não pode ser excluido";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
            return Result.Ok();
        }

        public Result<List<GrupoDeVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgError = "Falha no sistema ao tentar selecionar todos os grupos de veículos";

                Log.Logger.Error(ex, msgError);

                return Result.Fail(msgError);
            }
        }

        public Result<GrupoDeVeiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result Validar(GrupoDeVeiculos grupoDeVeiculos)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupoDeVeiculos);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                errors.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(grupoDeVeiculos))
                errors.Add(new Error("Nome Duplicado"));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
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
