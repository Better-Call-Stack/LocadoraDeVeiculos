﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Config;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteOrm repositorioCliente;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCliente(RepositorioClienteOrm repositorioCliente, IContextoPersistencia contexto)
        {
            this.repositorioCliente = repositorioCliente;
            this.contextoPersistencia = contexto;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok(cliente);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            var resultadoValidacao = ValidarCliente(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Debug("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@c}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                if (ex != null && ex.Message.Contains("The association between entities 'Condutor' and 'Locacao'"))
                {
                    string msgErroDelete = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";

                    Log.Logger.Error(ex, msgErroDelete + "{ClienteId}", cliente.Id);

                    return Result.Fail(msgErroDelete);

                }

                if (ex != null && ex.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    string msgErroDelete = "";
                    if (ex != null && ex.InnerException.Message.Contains("Condutor"))
                         msgErroDelete = $"O cliente {cliente.Nome} está relacionado com um condutor e não pode ser excluído";
                    
                    if (ex != null && ex.InnerException.Message.Contains("Locacao"))
                         msgErroDelete = $"O cliente {cliente.Nome} está relacionado com uma locação e não pode ser excluído";

                    Log.Logger.Error(ex, msgErroDelete + "{ClienteId}", cliente.Id);

                    return Result.Fail(msgErroDelete);

                }
                string msgErro = "Falha no sistema ao tentar excluir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }

        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
              return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex, msgErro);

               return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }


        private Result<Cliente> ValidarCliente(Cliente cliente)
        {
            var validadorCliente = new ValidadorCliente();

            var resultadoValidacao = validadorCliente.Validate(cliente);

            List<Error> erros = new List<Error>();
            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (CpfDuplicado(cliente))
               erros.Add(new Error("CPF Duplicado"));

            if (CnpjDuplicado(cliente))
               erros.Add(new Error("CNPJ Duplicado"));

            if(erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        } 

        private bool CpfDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCPF(cliente.CPF);

            return clienteEncontrado != null &&
                   cliente.TipoPessoa == TipoPessoa.Fisica &&
                   clienteEncontrado.CPF == cliente.CPF &&
                   clienteEncontrado.Id != cliente.Id;
        }


        private bool CnpjDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCNPJ(cliente.CNPJ);

            return clienteEncontrado != null &&
                   cliente.TipoPessoa == TipoPessoa.Juridica &&
                   clienteEncontrado.CNPJ == cliente.CNPJ &&
                   clienteEncontrado.Id != cliente.Id;
        }
    }
}
