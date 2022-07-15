using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Serilog;
using System;


namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioCliente repositorioCliente;
        private ValidadorCliente validadorCliente;
        

        public ServicoCliente(RepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente {ClienteId} inserido com sucesso", cliente.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Cliente {ClienteId} - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }

            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {


            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(cliente);
                Log.Logger.Debug("Cliente {ClienteId} editado com sucesso", cliente.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Cliente {ClienteId} - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }


        public ValidationResult Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir Cliente... {@Cliente}", cliente);

            repositorioCliente.Excluir(cliente);

            Log.Logger.Debug("Cliente com Id = '{ClienteId}' excluído com sucesso", cliente.Id);

            return new ValidationResult();
        }

        private ValidationResult Validar(Cliente cliente)
        {
            validadorCliente = new ValidadorCliente();

            var resultadoValidacao = validadorCliente.Validate(cliente);

            if (CpfDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF Duplicado"));

            if (CnpjDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ Duplicado"));

            return resultadoValidacao;
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
