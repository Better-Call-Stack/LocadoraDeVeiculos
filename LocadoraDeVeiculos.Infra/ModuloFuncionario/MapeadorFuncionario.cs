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
            var id = Guid.Parse(leitorFuncionario["FUNCIONARIO_ID"].ToString());
            var cpf = Convert.ToString(leitorFuncionario["FUNCIONARIO_CPF"]);
            var nome = Convert.ToString(leitorFuncionario["FUNCIONARIO_NOME"]);
            var salario = Convert.ToDecimal(leitorFuncionario["FUNCIONARIO_SALARIO"]);
            var dataDeAdmissao = Convert.ToDateTime(leitorFuncionario["FUNCIONARIO_DATADEADMISSAO"]);
            var login = Convert.ToString(leitorFuncionario["FUNCIONARIO_LOGIN"]);
            var senha = Convert.ToString(leitorFuncionario["FUNCIONARIO_SENHA"]);
            var perfil = (PerfilEnum)leitorFuncionario["FUNCIONARIO_PERFIL"];

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
