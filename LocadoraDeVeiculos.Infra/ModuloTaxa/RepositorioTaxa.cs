﻿using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxa : RepositorioBase<Taxa, ValidadorTaxa, MapeadorTaxa>
    {
        protected override string sqlInserir => @"
         INSERT INTO [DBO].[TBTAXA]
               (
	    	   [NOME],
               [VALOR],
               [TIPOCOBRANCA]
	    	   )
         VALUES
               (
	    	   @NOME,
               @VALOR,
               @TIPOCOBRANCA
	    	   )
		   
		SELECT SCOPE_IDENTITY();";

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
	}
}