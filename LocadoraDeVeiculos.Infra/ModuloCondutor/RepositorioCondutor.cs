using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBase<Condutor, ValidadorCondutor, MapeadorCondutor>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [DBO].[TBCONDUTOR]
                     (
                     [ID],
                     [NOME],
                     [CPF],
                     [CNH],
                     [VALIDADECNH],
                     [CIDADE],
                     [ENDERECO],
                     [TELEFONE],
                     [EMAIL],
                     [CLIENTE_ID]
                    )
               VALUES
                    (
                     @ID,
                     @NOME, 
                     @CPF, 
                     @CNH, 
                     @VALIDADECNH,
                     @CIDADE,
                     @ENDERECO, 
                     @TELEFONE, 
                     @EMAIL, 
                     @CLIENTE_ID
                    );
                    
";

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
                   CONDUTOR.[ID] CONDUTOR_ID,
                   CONDUTOR.[NOME] CONDUTOR_NOME,
                   CONDUTOR.[CPF] CONDUTOR_CPF,
                   CONDUTOR.[CNH] CONDUTOR_CNH,
                   CONDUTOR.[VALIDADECNH] CONDUTOR_VALIDADECNH,
                   CONDUTOR.[CIDADE] CONDUTOR_CIDADE,
                   CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
                   CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
                   CONDUTOR.[EMAIL] CONDUTOR_EMAIL,


                   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CONDUTOR.[CLIENTE_ID]  = CLIENTE.[ID]

                WHERE 
            	    CONDUTOR.[ID] = @ID
            ";
        protected override string sqlSelecionarTodos =>
             @"SELECT
                   CONDUTOR.[ID] CONDUTOR_ID,
                   CONDUTOR.[NOME] CONDUTOR_NOME,
                   CONDUTOR.[CPF] CONDUTOR_CPF,
                   CONDUTOR.[CNH] CONDUTOR_CNH,
                   CONDUTOR.[VALIDADECNH] CONDUTOR_VALIDADECNH,
                   CONDUTOR.[CIDADE] CONDUTOR_CIDADE,
                   CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
                   CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
                   CONDUTOR.[EMAIL]  CONDUTOR_EMAIL,

                   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CLIENTE.[ID] = CONDUTOR.[CLIENTE_ID] ";

        private string sqlSelecionarPorCPF =>
            @"SELECT
                   CONDUTOR.[ID] CONDUTOR_ID,
                   CONDUTOR.[NOME] CONDUTOR_NOME,
                   CONDUTOR.[CPF] CONDUTOR_CPF,
                   CONDUTOR.[CNH] CONDUTOR_CNH,
                   CONDUTOR.[VALIDADECNH] CONDUTOR_VALIDADECNH,
                   CONDUTOR.[CIDADE] CONDUTOR_CIDADE,
                   CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
                   CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
                   CONDUTOR.[EMAIL] CONDUTOR_EMAIL,


                   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CONDUTOR.[CLIENTE_ID]  = CLIENTE.[ID]

                WHERE 
            	    CONDUTOR.[CPF] = @CPF";

        private string sqlSelecionarPorCNH =>
           @"SELECT
                   CONDUTOR.[ID] CONDUTOR_ID,
                   CONDUTOR.[NOME] CONDUTOR_NOME,
                   CONDUTOR.[CPF] CONDUTOR_CPF,
                   CONDUTOR.[CNH] CONDUTOR_CNH,
                   CONDUTOR.[VALIDADECNH] CONDUTOR_VALIDADECNH,
                   CONDUTOR.[CIDADE] CONDUTOR_CIDADE,
                   CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
                   CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
                   CONDUTOR.[EMAIL] CONDUTOR_EMAIL,


                   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
              
                FROM [TBCONDUTOR] AS CONDUTOR INNER JOIN
				[TBCLIENTE] AS CLIENTE

                ON 
                    CONDUTOR.[CLIENTE_ID]  = CLIENTE.[ID]

                WHERE 
            	    CONDUTOR.[CNH] = @CNH";

        public Condutor SelecionarCondutorPorCPF(string CPF)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", CPF));

        }

        public Condutor SelecionarCondutorPorCNH(string CNH)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNH, new SqlParameter("CNH", CNH));
        }

    }
   
}
