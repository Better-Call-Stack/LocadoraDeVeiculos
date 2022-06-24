using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario, ValidadorFuncionario, MapeadorFuncionario>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBFUNCIONARIO]
                (
                     [NOME],
                     [SALARIO],
                     [DATADEADMISSAO],
                     [LOGIN],
                     [SENHA],
                     [PERFIL])
            VALUES
                (
                     @NOME,
                     @SALARIO,
                     @DATADEADMISSAO,
                     @LOGIN,
                     @SENHA,
                     @PERFIL
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBFUNCIONARIO]
                    SET 
                        [NOME] = @NOME,
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
                [NOME],
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
                [NOME],
                [SALARIO],
                [DATADEADMISSAO],
                [LOGIN],
                [SENHA],
                [PERFIL]
            FROM
                [TBFUNCIONARIO]";
    }
}
