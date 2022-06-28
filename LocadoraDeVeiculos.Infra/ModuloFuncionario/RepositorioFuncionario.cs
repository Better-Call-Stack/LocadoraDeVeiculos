using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                     [NOME],
                     [CPF],
                     [SALARIO],
                     [DATADEADMISSAO],
                     [LOGIN],
                     [SENHA],
                     [PERFIL])
            VALUES
                (
                     @NOME,
                     @CPF,
                     @SALARIO,
                     @DATADEADMISSAO,
                     @LOGIN,
                     @SENHA,
                     @PERFIL
                )
                    SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBFUNCIONARIO]
                    SET 
                        [NOME] = @NOME,
                        [CPF] = @CPF,
                        [SALARIO] = @SALARIO,
                        [DATADEADMISSAO] = @DATADEADMISSAO,
                        [LOGIN] = @LOGIN, 
                        [SENHA] = @SENHA,
                        [PERFIL] = @PERFIL
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBFUNCIONARIO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                [NOME],
                [CPF],
                [SALARIO],
                [DATADEADMISSAO],
                [LOGIN],
                [SENHA],
                [PERFIL]
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                [ID],
                [NOME],
                [CPF],
                [SALARIO],
                [DATADEADMISSAO],
                [LOGIN],
                [SENHA],
                [PERFIL]
            FROM
                [TBFUNCIONARIO]";

        public override ValidationResult Inserir(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            ValidacaoCPFFuncionario(registro, resultadoValidacao);
            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new MapeadorFuncionario();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public override ValidationResult Editar(Funcionario registro)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(registro);

            ValidacaoCPFFuncionario(registro, resultadoValidacao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            var mapeador = new MapeadorFuncionario();

            mapeador.ConfigurarParametros(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public override List<Funcionario> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }

        private void ValidacaoCPFFuncionario(Funcionario registro, ValidationResult resultadoValidacao)
        {
            Funcionario fRepetido = new Funcionario();

            bool cpfRepetido = false;
            foreach (var f in SelecionarTodos())
            {
                if (registro.CPF == f.CPF)
                {
                    cpfRepetido = true;
                    fRepetido = f;
                }
            }

            if (cpfRepetido == true && registro.Id != fRepetido.Id)
            {
                resultadoValidacao
                  .Errors
                  .Add(new ValidationFailure("", "CPF já cadastrado."));
            }

        }
    }
}
