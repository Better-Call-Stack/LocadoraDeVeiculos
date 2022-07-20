using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                     [ID],
                     [NOME],
                     [CPF],
                     [SALARIO],
                     [DATADEADMISSAO],
                     [LOGIN],
                     [SENHA],
                     [PERFIL])
            VALUES
                (
                     @ID,
                     @NOME,
                     @CPF,
                     @SALARIO,
                     @DATADEADMISSAO,
                     @LOGIN,
                     @SENHA,
                     @PERFIL
                )
                    ";

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
               [ID] FUNCIONARIO_ID,       
               [NOME] FUNCIONARIO_NOME,
               [CPF] FUNCIONARIO_CPF,
               [SALARIO] FUNCIONARIO_SALARIO,
               [DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO,
               [LOGIN] FUNCIONARIO_LOGIN,
               [SENHA] FUNCIONARIO_SENHA,
               [PERFIL] FUNCIONARIO_PERFIL
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT
                [ID] FUNCIONARIO_ID,       
                [NOME] FUNCIONARIO_NOME,
                [CPF] FUNCIONARIO_CPF,
                [SALARIO] FUNCIONARIO_SALARIO,
                [DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO,
                [LOGIN] FUNCIONARIO_LOGIN,
                [SENHA] FUNCIONARIO_SENHA,
                [PERFIL] FUNCIONARIO_PERFIL
            FROM
                [TBFUNCIONARIO]";

        private string sqlSelecionarPorCPF =>
            @"SELECT
				[ID] FUNCIONARIO_ID,       
                [NOME] FUNCIONARIO_NOME,
                [CPF] FUNCIONARIO_CPF,
                [SALARIO] FUNCIONARIO_SALARIO,
                [DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO,
                [LOGIN] FUNCIONARIO_LOGIN,
                [SENHA] FUNCIONARIO_SENHA,
                [PERFIL] FUNCIONARIO_PERFIL
			FROM
				[TBFUNCIONARIO]
			WHERE
				[CPF] = @CPF";
        private string sqlSelecionarPorLogin =>
           @"SELECT 
                   [ID] FUNCIONARIO_ID,       
                   [NOME] FUNCIONARIO_NOME,
                   [CPF] FUNCIONARIO_CPF,
                   [SALARIO] FUNCIONARIO_SALARIO,
                   [DATADEADMISSAO] FUNCIONARIO_DATADEADMISSAO,
                   [LOGIN] FUNCIONARIO_LOGIN,
                   [SENHA] FUNCIONARIO_SENHA,
                   [PERFIL] FUNCIONARIO_PERFIL
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [LOGIN] = @LOGIN";

        public Funcionario SelecionarFuncionarioPorCPF(string CPF)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", CPF));
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return SelecionarPorParametro(sqlSelecionarPorLogin, new SqlParameter("LOGIN", login));
        }
    }
}
