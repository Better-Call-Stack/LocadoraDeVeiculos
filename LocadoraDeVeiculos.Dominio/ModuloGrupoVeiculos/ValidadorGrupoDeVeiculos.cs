using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class ValidadorGrupoDeVeiculos : AbstractValidator<GrupoDeVeiculos>
    {
        public ValidadorGrupoDeVeiculos()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O campo nome é obrigatório")
                .NotEmpty().WithMessage("O campo nome é obrigatório");

            RuleFor(x => x.ValorPlanoDiario)
                .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiariaKmControlado)
                .NotNull().WithMessage("O campo valor diaria Km controlador é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiarioKmLivre)
                .NotNull().WithMessage("O campo valor diario Km livre é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");
        }
    }
}
