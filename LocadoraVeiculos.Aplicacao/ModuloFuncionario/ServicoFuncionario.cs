using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private RepositorioFuncionarioOrm repositorioFuncionario;
        private IContextoPersistencia contextoPersistencia;

        public ServicoFuncionario(RepositorioFuncionarioOrm repositorioFuncionario, IContextoPersistencia contexto)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.contextoPersistencia = contexto;
        }

        public Result<Funcionario> Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário... {@f}", funcionario);

            Result resultadoValidacao = ValidarFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Funcionário {FuncionarioId} - {Motivo}",
                       funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Inserir(funcionario);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioId} inserido com sucesso", funcionario.Id);

                return Result.Ok(funcionario);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar cadastrar o colaborador.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionario... {@f}", funcionario);

            var resultadoValidacao = ValidarFuncionario(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Funcionario {FuncionarioId} - {Motivo}",
                       funcionario.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Editar(funcionario);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Funcionário {FuncionarioId} editado com sucesso", funcionario.Id);

                return Result.Ok(funcionario);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar os dados.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir funcionario... {@f}", funcionario);

            try
            {
                repositorioFuncionario.Excluir(funcionario);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Funcionario {FuncionarioId} excluído com sucesso", funcionario.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir os dados.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", funcionario.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Funcionario>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os colaboradores.";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o colaborador.";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarFuncionario(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>(); 

            foreach (ValidationFailure item in resultadoValidacao.Errors)         
                erros.Add(new Error(item.ErrorMessage));

            if (CpfDuplicado(funcionario))
                erros.Add(new Error("CPF duplicado"));

            if (UsuarioDuplicado(funcionario))
                erros.Add(new Error("Login duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CpfDuplicado (Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorCPF(funcionario.CPF);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.CPF == funcionario.CPF &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool UsuarioDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

    }
   
}
