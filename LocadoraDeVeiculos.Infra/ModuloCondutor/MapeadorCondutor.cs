using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor condutor, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", condutor.Id);
            comando.Parameters.AddWithValue("NOME", condutor.Nome);
            comando.Parameters.AddWithValue("TELEFONE", condutor.Telefone);
            comando.Parameters.AddWithValue("EMAIL", condutor.Email);
            comando.Parameters.AddWithValue("CIDADE", condutor.Cidade);
            comando.Parameters.AddWithValue("CNH", condutor.CNH);
            comando.Parameters.AddWithValue("VALIDADECNH", condutor.ValidadeCNH);
            comando.Parameters.AddWithValue("CPF", condutor.CPF);
            comando.Parameters.AddWithValue("ENDERECO", condutor.Endereco);
            comando.Parameters.AddWithValue("CLIENTE_ID", condutor.Cliente.Id);
        }

        public override Condutor ConverterRegistro(SqlDataReader leitorCondutor)
        {
            var id = Convert.ToInt32(leitorCondutor["ID"]);
            var nome = Convert.ToString(leitorCondutor["NOME"]);
            var telefone = Convert.ToString(leitorCondutor["TELEFONE"]);
            var email = Convert.ToString(leitorCondutor["EMAIL"]);
            var cidade = Convert.ToString(leitorCondutor["CIDADE"]);
            var cnh = Convert.ToString(leitorCondutor["CNH"]);
            var validadeCnh = Convert.ToDateTime(leitorCondutor["VALIDADECNH"]);
            var cpf = Convert.ToString(leitorCondutor["CPF"]);
            var endereco = Convert.ToString(leitorCondutor["ENDERECO"]);
            var idCliente = Convert.ToInt32(leitorCondutor["CLIENTE_ID"]);

            var nomeCliente

            Condutor condutor = new Condutor();
            condutor.Id = id;
            condutor.Nome = nome;
            condutor.Telefone = telefone;
            condutor.Email = email;
            condutor.Cidade = cidade;
            condutor.CNH = cnh;
            condutor.ValidadeCNH = validadeCnh;
            condutor.CPF = cpf;
            condutor.Endereco = endereco;
            condutor.Cliente.Id = idCliente;


            return condutor;
        }
    }
}
