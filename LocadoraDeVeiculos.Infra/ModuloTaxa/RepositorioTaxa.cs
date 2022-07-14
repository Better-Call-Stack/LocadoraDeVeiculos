using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir => @"
         INSERT INTO [DBO].[TBTAXA]
               (
               [ID],
	    	   [NOME],
               [VALOR],
               [TIPOCOBRANCA]
	    	   )
         VALUES
               (
               @ID,
	    	   @NOME,
               @VALOR,
               @TIPOCOBRANCA
	    	   )
		   
		";

        protected override string sqlEditar => @"
          UPDATE [dbo].[TbTaxa]
         SET 
	         [Nome] = @NOME,
             [Valor] = @VALOR,
             [TipoCobranca] = @TIPOCOBRANCA
 
	        WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXA]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
				[ID],
			    [NOME],
                [VALOR],
                [TIPOCOBRANCA]
			FROM
				[TBTAXA]
			WHERE
				[ID] = @ID";

        protected override string sqlSelecionarTodos =>
                @"SELECT
				[ID],
				[NOME],
				[VALOR],
                [TIPOCOBRANCA]
			FROM
				[TBTAXA]
			";

        private string sqlSelecionarPorNome =>
            @"SELECT
				[ID],
			    [NOME],
                [VALOR],
                [TIPOCOBRANCA]
			FROM
				[TBTAXA]
			WHERE
				[NOME] = @NOME";

        
        public Taxa SelecionarTaxaPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        } 
    }
}
