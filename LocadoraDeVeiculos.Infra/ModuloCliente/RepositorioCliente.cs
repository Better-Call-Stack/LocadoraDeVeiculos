using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public override ValidationResult Inserir(Cliente registro)
        {
			var validador = new ValidadorCliente();

			var resultadoValidacao = validador.Validate(registro);
			
			ValidacaoDuplicados(registro, resultadoValidacao);

			SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

			SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

			var mapeador = new MapeadorCliente();

			mapeador.ConfigurarParametros(registro, comandoInsercao);

			conexaoComBanco.Open();
			var id = comandoInsercao.ExecuteScalar();
			registro.Id = Convert.ToInt32(id);

			conexaoComBanco.Close();

			return resultadoValidacao;
		}

        public override ValidationResult Editar(Cliente registro)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(registro);

            ValidacaoDuplicados(registro, resultadoValidacao);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            var mapeador = new MapeadorCliente();

            mapeador.ConfigurarParametros(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        private void ValidacaoDuplicados(Cliente registro, ValidationResult resultadoValidacao)
        {
			Cliente cRepetido = new Cliente();

			bool cpfRepetido = false;
			foreach (var c in SelecionarTodos())
			{
				if (registro.CPF == c.CPF)
				{
					cpfRepetido = true;
					cRepetido = c;
				}
			}

			bool cnpjRepetido = false;
			foreach (var c in SelecionarTodos())
			{
				if (registro.CNPJ == c.CNPJ)
				{
					cnpjRepetido = true;
					cRepetido = c;
				}
			}

			bool cnhRepetida = false;
            foreach (var c in SelecionarTodos())
            {
				if (registro.CNH == c.CNH)
				{
					cnhRepetida = true;
					cRepetido = c;
				}
			}


            if (cpfRepetido && registro.TipoPessoa == TipoPessoa.Fisica && registro.Id != cRepetido.Id)
            {
                resultadoValidacao
                  .Errors
                  .Add(new ValidationFailure("", "CPF já existe."));
            }

            if (cnpjRepetido && registro.TipoPessoa == TipoPessoa.Juridica && registro.Id != cRepetido.Id)
            {
                resultadoValidacao
                  .Errors
                  .Add(new ValidationFailure("", "CNPJ já existe."));
            }

            if (cnhRepetida && registro.TipoPessoa == TipoPessoa.Fisica && registro.Id != cRepetido.Id)
            {
                resultadoValidacao
                  .Errors
                  .Add(new ValidationFailure("", "CNH já existe."));
            }
        }

        public override List<Cliente> SelecionarTodos()
        {
            return base.SelecionarTodos();
        }
    }
}
