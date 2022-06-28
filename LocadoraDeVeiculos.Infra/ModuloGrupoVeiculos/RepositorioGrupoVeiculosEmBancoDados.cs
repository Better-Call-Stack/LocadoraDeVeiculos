using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : RepositorioBase<GrupoDeVeiculos, ValidadorGrupoDeVeiculos, MapeadorGrupoVeiculos>
    {

        public RepositorioGrupoVeiculosEmBancoDados()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS; DBCC CHECKIDENT (TBGRUPOVEICULOS, RESEED, 0)");
        }
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPOVEICULOS]
                (
                     [NOME],
                     [VALORPLANODIARIO],
                     [VALORDIARIAKMCONTROLADO],
                     [VALORDIARIOKMLIVRE])
            VALUES
                (
                     @NOME,
                     @VALORPLANODIARIO,
                     @VALORDIARIAKMCONTROLADO,
                     @VALORDIARIOKMLIVRE
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBGRUPOVEICULOS]
                    SET 
                        [NOME] = @NOME,
                        [VALORPLANODIARIO] = @VALORPLANODIARIO,
                        [VALORDIARIAKMCONTROLADO] = @VALORDIARIAKMCONTROLADO,
                        [VALORDIARIOKMLIVRE] = @VALORDIARIOKMLIVRE
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                [NOME],
                [VALORPLANODIARIO],
                [VALORDIARIAKMCONTROLADO],
                [VALORDIARIOKMLIVRE]
            FROM
                [TBGRUPOVEICULOS]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
                [NOME],
                [VALORPLANODIARIO],
                [VALORDIARIAKMCONTROLADO],
                [VALORDIARIOKMLIVRE]
            FROM
                [TBGRUPOVEICULOS]";


    }
}

