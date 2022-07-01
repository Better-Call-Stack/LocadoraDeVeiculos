using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
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
				[ID],
				[NOME],
				[CPF],
				[CNPJ],
				[CIDADE],
				[ENDERECO],
				[TELEFONE],
				[TIPOPESSOA],
				[EMAIL]
			FROM
				[TBCLIENTE]

			WHERE
				[ID] = @ID";

		protected override string sqlSelecionarTodos =>
			@"SELECT
				[ID],
				[NOME],
				[CPF],
				[CNPJ],
				[CIDADE],
				[ENDERECO],
				[TELEFONE],
				[TIPOPESSOA],
				[EMAIL]
			FROM
				[TBCLIENTE]
			";

		private string sqlSelecionarPorCPF =>
			@"SELECT
				[ID],
				[NOME],
				[CPF],
				[CNPJ],
				[CIDADE],
				[ENDERECO],
				[TELEFONE],
				[TIPOPESSOA],
				[EMAIL]
			FROM
				[TBCLIENTE]
			WHERE
				[CPF] = @CPF";

		private string sqlSelecionarPorCNPJ =>
			@"SELECT
				[ID],
				[NOME],
				[CPF],
				[CNPJ],
				[CIDADE],
				[ENDERECO],
				[TELEFONE],
				[TIPOPESSOA],
				[EMAIL]
			FROM
				[TBCLIENTE]
			WHERE
				[CNPJ] = @CNPJ";

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
