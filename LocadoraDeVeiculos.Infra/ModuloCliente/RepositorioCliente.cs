using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioCliente : RepositorioBase<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBCLIENTE]
				(
					[NOME],
					[CPF],
					[CNPJ],
					[CIDADE],
					[ENDERECO],
					[TELEFONE],
					[TIPOPESSOA],
					[EMAIL]
				)
				VALUES 
				(
					@NOME,
					@CPF,
					@CNPJ,
					@CIDADE,
					@ENDERECO,
					@TELEFONE,
					@TIPOPESSOA,
					@EMAIL
				)
				SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBCLIENTE]
				SET
					[NOME] = @NOME,
					[CPF] = @CPF,
					[CNPJ] = @CNPJ,
					[CIDADE] = @CIDADE,
					[ENDERECO] = @ENDERECO,
					[TELEFONE] = @TELEFONE,
					[TIPOPESSOA] = @TIPOPESSOA,
					[EMAIL] = @EMAIL
				WHERE
					ID = @ID

					";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
                WHERE [ID] = @ID";

		protected override string sqlSelecionarPorId =>

			
			@"SELECT
				   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
			FROM
				[TBCLIENTE] AS CLIENTE

			WHERE
				[ID] = @ID";

		protected override string sqlSelecionarTodos =>
			@"SELECT
				 CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
			FROM
				[TBCLIENTE] AS CLIENTE
			";

		private string sqlSelecionarPorCPF =>
			@"SELECT
				   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
			FROM
				[TBCLIENTE] AS CLIENTE
			WHERE
				CLIENTE.[CPF] = @CPF";

		private string sqlSelecionarPorCNPJ =>
			@"SELECT
				   CLIENTE.[ID] CLIENTE_ID,
                   CLIENTE.[NOME] CLIENTE_NOME,
                   CLIENTE.[CPF] CLIENTE_CPF,
		           CLIENTE.[CNPJ] CLIENTE_CNPJ,
			   	   CLIENTE.[CIDADE] CLIENTE_CIDADE,
				   CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				   CLIENTE.[TELEFONE] CLIENTE_TELEFONE,
				   CLIENTE.[TIPOPESSOA] CLIENTE_TIPOPESSOA,
				   CLIENTE.[EMAIL] CLIENTE_EMAIL
			FROM
				[TBCLIENTE] AS CLIENTE
			WHERE
				CLIENTE.[CNPJ] = @CNPJ";

        public Cliente SelecionarClientePorCPF(string CPF)
        {
            return SelecionarPorParametro(sqlSelecionarPorCPF, new SqlParameter("CPF", CPF));

        }

        public Cliente SelecionarClientePorCNPJ(string CNPJ)
        {
            return SelecionarPorParametro(sqlSelecionarPorCNPJ, new SqlParameter("CNPJ", CNPJ));

        }

    }
}
