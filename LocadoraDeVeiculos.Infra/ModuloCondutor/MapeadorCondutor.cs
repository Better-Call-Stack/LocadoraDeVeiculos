using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
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
            var id = Convert.ToInt32(leitorCondutor["CONDUTOR_ID"]);
            var nome = Convert.ToString(leitorCondutor["CONDUTOR_NOME"]);
            var telefone = Convert.ToString(leitorCondutor["CONDUTOR_TELEFONE"]);
            var email = Convert.ToString(leitorCondutor["CONDUTOR_EMAIL"]);
            var cidade = Convert.ToString(leitorCondutor["CONDUTOR_CIDADE"]);
            var cnh = Convert.ToString(leitorCondutor["CONDUTOR_CNH"]);
            var validadeCnh = Convert.ToDateTime(leitorCondutor["CONDUTOR_VALIDADECNH"]);
            var cpf = Convert.ToString(leitorCondutor["CONDUTOR_CPF"]);
            var endereco = Convert.ToString(leitorCondutor["CONDUTOR_ENDERECO"]);



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

            condutor.Cliente = new MapeadorCliente().ConverterRegistro(leitorCondutor);
          

            return condutor;
        }
    }
}
