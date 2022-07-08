using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        private string sqlSelecionarPorCPF =>
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
				[CPF] = @CPF";

       public Funcionario SelecionarFuncionarioPorCPF(string CPF)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", CPF));
        }
    }
}
