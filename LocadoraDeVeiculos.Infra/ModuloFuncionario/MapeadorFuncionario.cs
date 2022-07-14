using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario funcionario, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", funcionario.Id);
            comando.Parameters.AddWithValue("CPF", funcionario.CPF);
            comando.Parameters.AddWithValue("NOME", funcionario.Nome);
            comando.Parameters.AddWithValue("SALARIO", funcionario.Salario);
            comando.Parameters.AddWithValue("DATADEADMISSAO", funcionario.DataDeAdmissao);
            comando.Parameters.AddWithValue("LOGIN", funcionario.Login);
            comando.Parameters.AddWithValue("SENHA", funcionario.Senha);
            comando.Parameters.AddWithValue("PERFIL", funcionario.Perfil);
        }
        public override Funcionario ConverterRegistro(SqlDataReader leitorFuncionario)
        {
            var id = Guid.Parse(leitorFuncionario["ID"].ToString());
            var cpf = Convert.ToString(leitorFuncionario["CPF"]);
            var nome = Convert.ToString(leitorFuncionario["NOME"]);
            var salario = Convert.ToDecimal(leitorFuncionario["SALARIO"]);
            var dataDeAdmissao = Convert.ToDateTime(leitorFuncionario["DATADEADMISSAO"]);
            var login = Convert.ToString(leitorFuncionario["LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["SENHA"]);
            var perfil = (PerfilEnum)leitorFuncionario["PERFIL"];

            Funcionario funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.CPF = cpf;
            funcionario.Nome = nome;
            funcionario.Salario = salario;
            funcionario.DataDeAdmissao = dataDeAdmissao;
            funcionario.Login = login;
            funcionario.Senha = senha;
            funcionario.Perfil = perfil;

            return funcionario;
        }
    }
}
