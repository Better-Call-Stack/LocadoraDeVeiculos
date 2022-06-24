using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : RepositorioBase<GrupoDeVeiculos, ValidadorGrupoDeVeiculos, MapeadorGrupoVeiculos>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS]
                (
                     [NOME],
                     [VALORPLANODIARIO],
                     [VALORDIARIOKMCONTROLADO],
                     [VALORDIARIOKMLIVRE])
            VALUES
                (
                     @NOME,
                     @VALORPLANODIARIO,
                     @VALORDIARIOKMCONTROLADO,
                     @VALORDIARIOKMLIVRE
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBGRUPOVEICULOS]
                    SET 
                        [NOME] = @NOME,
                        [VALORPLANODIARIO] = @VALORPLANODIARIO,
                        [VALORDIARIOKMCONTROLADO] = @VALORDIARIOKMCONTROLADO,
                        [VALORDIARIOKMLIVRE] = @VALORDIARIOKMLIVRE
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [NOME],
                [VALORPLANODIARIO],
                [VALORDIARIOKMCONTROLADO],
                [VALORDIARIOKMLIVRE]
            FROM
                [TBGRUPOVEICULOS]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [NOME],
                [VALORPLANODIARIO],
                [VALORDIARIOKMCONTROLADO],
                [VALORDIARIOKMLIVRE]
            FROM
                [TBGRUPOVEICULOS]";
    }
}

