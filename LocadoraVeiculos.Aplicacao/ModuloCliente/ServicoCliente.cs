using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
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
