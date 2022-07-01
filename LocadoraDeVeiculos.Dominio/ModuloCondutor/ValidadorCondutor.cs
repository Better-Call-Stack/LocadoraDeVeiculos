using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("Nome é campo obrigatório")
                .NotEmpty().WithMessage("Nome é campo obrigatório");

            RuleFor(x => x.CNH).NotNull().WithMessage("CNH é campo obrigatório")
                .NotEmpty().WithMessage("CNH é campo obrigatório");

            RuleFor(x => x.ValidadeCNH).NotNull().WithMessage("Validade CNH é campo obrigatório")
                .NotEmpty().WithMessage("Validade CNH é campo obrigatório");

            RuleFor(x => x.Cliente).NotNull().WithMessage("Campo Cliente é obrigatório")
                .NotEmpty().WithMessage("Campo Cliente é obrigatório");
        }
    }
}
