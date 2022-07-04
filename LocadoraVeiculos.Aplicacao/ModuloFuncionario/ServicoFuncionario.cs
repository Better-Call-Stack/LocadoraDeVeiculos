using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
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

        public ServicoFuncionario(RepositorioFuncionario repositorioFuncionario, ValidadorFuncionario validadorFuncionario)
        {
            this.repositorioFuncionario=repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Inserir(funcionario);

            return resultadoValidacao;
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

        public ValidationResult Editar(Funcionario funcionario)
        {
            var resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
                repositorioFuncionario.Editar(funcionario);

            return resultadoValidacao;
        }
    }
}
