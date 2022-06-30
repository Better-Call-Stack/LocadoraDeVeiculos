using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente cliente, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", cliente.Id);
            comando.Parameters.AddWithValue("NOME", cliente.Nome);
            comando.Parameters.AddWithValue("TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("EMAIL", cliente.Email);
            comando.Parameters.AddWithValue("CIDADE", cliente.Cidade);
            comando.Parameters.AddWithValue("CPF", cliente.CPF);
            comando.Parameters.AddWithValue("CNPJ", cliente.CNPJ);
            comando.Parameters.AddWithValue("TIPOPESSOA", cliente.TipoPessoa);
            comando.Parameters.AddWithValue("ENDERECO", cliente.Endereco);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorCliente)
        {
            var id = Convert.ToInt32(leitorCliente["ID"]);
            var nome = Convert.ToString(leitorCliente["NOME"]);
            var telefone = Convert.ToString(leitorCliente["TELEFONE"]);
            var email = Convert.ToString(leitorCliente["EMAIL"]);
            var cidade = Convert.ToString(leitorCliente["CIDADE"]);
            var cpf = Convert.ToString(leitorCliente["CPF"]);
            var cnpj = Convert.ToString(leitorCliente["CNPJ"]);
            var tipoPessoa = (TipoPessoa)leitorCliente["TIPOPESSOA"];
            var endereco = Convert.ToString(leitorCliente["ENDERECO"]);

            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.Telefone = telefone;
            cliente.Email = email;
            cliente.Cidade = cidade;
            cliente.CPF = cpf;
            cliente.CNPJ = cnpj;
            cliente.TipoPessoa = tipoPessoa;
            cliente.Endereco = endereco;



            return cliente;
        }
    }
}
