using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBase<Condutor, ValidadorCondutor, MapeadorCondutor>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [DBO].[TBCONDUTOR]
                     ([NOME]
                     ,[CPF]
                     ,[CNH]
                     ,[VALIDADECNH]
                     ,[CIDADE]
                     ,[ENDERECO]
                     ,[TELEFONE]
                     ,[EMAIL]
                     ,[CLIENTE_ID])
               VALUES
                    (@NOME, 
                     @CPF, 
                     @CNH, 
                     @VALIDADECNH,
                     @CIDADE,
                     @ENDERECO, 
                     @TELEFONE, 
                     @EMAIL, 
                     @CLIENTE_ID";

        protected override string sqlEditar =>
            @"UPDATE [dbo].[TbCondutor]

              SET [NOME] = @NOME,
                  [CPF] = @CPF, 
                  [CNH] = @CNH, 
                  [VALIDADECNH] = @VALIDADECNH,
                  [CIDADE] = @CIDADE, 
                  [ENDERECO] = @ENDERECO,
                  [TELEFONE] = @TELEFONE, 
                  [EMAIL] = @EMAIL, 
                  [CLIENTE_ID] = @CLIENTE_ID
            	 
                WHERE 
            		[ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCONDUTOR]
                WHERE 
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT
                   CONDUTOR.[ID]
                   CONDUTOR.[NOME],
                   CONDUTOR.[CPF],
                   CONDUTOR.[CNH],
                   CONDUTOR.[VALIDADECNH],
                   CONDUTOR.[CIDADE],
                   CONDUTOR.[ENDERECO],
                   CONDUTOR.[TELEFONE],
                   CONDUTOR.[EMAIL],
                   CONDUTOR.[CLIENTE_ID]

                   CLIENTE.[NOME],
                   CLIENTE.[CPF],
		           CLIENTE.[CNPJ],
			   	   CLIENTE.[CIDADE],
				   CLIENTE.[ENDERECO],
				   CLIENTE.[TELEFONE],
				   CLIENTE.[TIPOPESSOA],
				   CLIENTE.[EMAIL]
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CLIENTE.[ID] = CONDUTOR.[CLIENTE_ID] 

                WHERE 
            	    CONDUTOR.[ID] = @ID
            ";
        protected override string sqlSelecionarTodos =>
             @"SELECT
                   CONDUTOR.[ID]
                   CONDUTOR.[NOME],
                   CONDUTOR.[CPF],
                   CONDUTOR.[CNH],
                   CONDUTOR.[VALIDADECNH],
                   CONDUTOR.[CIDADE],
                   CONDUTOR.[ENDERECO],
                   CONDUTOR.[TELEFONE],
                   CONDUTOR.[EMAIL],
                   CONDUTOR.[CLIENTE_ID]

                   CLIENTE.[NOME],
                   CLIENTE.[CPF],
		           CLIENTE.[CNPJ],
			   	   CLIENTE.[CIDADE],
				   CLIENTE.[ENDERECO],
				   CLIENTE.[TELEFONE],
				   CLIENTE.[TIPOPESSOA],
				   CLIENTE.[EMAIL]
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CLIENTE.[ID] = CONDUTOR.[CLIENTE_ID] ";
    }
}
