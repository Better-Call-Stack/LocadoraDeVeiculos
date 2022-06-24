using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
               .NotNull().NotEmpty();

            RuleFor(x => x.Salario)
                .NotNull().NotEmpty();

            RuleFor(x => x.DataDeAdmissao)
                 .NotEqual(DateTime.MinValue);

            RuleFor(x => x.Login)
                .MinimumLength(3)
                .NotNull().NotEmpty();

            RuleFor(x => x.Senha)
                .MinimumLength(6)
                .NotNull().NotEmpty();

        }
    }
}
