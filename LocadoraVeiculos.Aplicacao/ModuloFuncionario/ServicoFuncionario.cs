using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private RepositorioFuncionario repositorioFuncionario;
        private ValidadorFuncionario validadorFuncionario;

        public ServicoFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario=repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionario... {@f}", funcionario);

            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Debug("Funcionario {FuncionarioId} inserido com sucesso", funcionario.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionario {FuncionarioId} - {Motivo}",
                        funcionario.Id, erro.ErrorMessage);
                }

            }
            return resultadoValidacao;
        }
       
        public ValidationResult Editar(Funcionario funcionario)
        {

            Log.Logger.Debug("Tentando editar funcionario... {@f}", funcionario);
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(funcionario);
                Log.Logger.Debug("Funcionario {FuncionarioId} editado com sucesso", funcionario.Id);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Funcionario {FuncionarioId} - {Motivo}",
                        funcionario.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Funcionario funcionario)
        {
            Log.Logger.Debug("Tentando excluir Funcionario... {@Funcionario}", funcionario);

            repositorioFuncionario.Excluir(funcionario);

            Log.Logger.Debug("Funcionario com Id = '{FuncionarioId}' excluído com sucesso", funcionario.Id);

            return new ValidationResult();
        }

        private ValidationResult Validar(Funcionario funcionario)
        {
            validadorFuncionario = new ValidadorFuncionario();

            var resultadoValidacao = validadorFuncionario.Validate(funcionario);

            if (CpfDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF já cadastrado."));

            return resultadoValidacao;
        }

        private bool CpfDuplicado (Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorCPF(funcionario.CPF);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.CPF == funcionario.CPF &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

    }
   
}
