using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

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
                     [NOME]
                )
            VALUES
                (
                     @NOME
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBGRUPOVEICULOS]
                    SET 
                        [NOME] = @NOME
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPOVEICULOS] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                [NOME]

            FROM
                [TBGRUPOVEICULOS]
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
                [NOME]
            FROM
                [TBGRUPOVEICULOS]";

        protected string sqlSelecionarPorNome =>
            @"SELECT 
                [ID],
                [NOME]
            FROM
                [TBGRUPOVEICULOS]
            WHERE
                [NOME] = @NOME";


        public GrupoDeVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }
    }
}

