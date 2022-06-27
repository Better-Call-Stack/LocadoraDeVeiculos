using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O campo Nome é obrigatório")
                .NotEmpty().WithMessage("O campo Nome é obrigatório");

            RuleFor(x => x.Valor).NotNull().WithMessage("O campo Valor é obrigatório")
            .NotEmpty().WithMessage("O campo Valor é obrigatório")
            .GreaterThanOrEqualTo(0).WithMessage("Valor inválido");

            RuleFor(x => x.Tipo).NotNull().WithMessage("O campo Tipo de Calculo é obrigatório")
                .NotEmpty().WithMessage("O campo Tipo de Calculo é obrigatório");
        }
    }
}
