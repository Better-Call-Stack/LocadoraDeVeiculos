using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
					[CNH],
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
					@CNH,
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
					[CNH] = @CNH,
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
				[CNH],
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
				[CNH],
				[TIPOPESSOA],
				[EMAIL]
			FROM
				[TBCLIENTE]
			";
    }
}
