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

            //Any(x => x.Nome == project.Nome && x.Nome == project.Nome);

            RuleFor(x => x.Nome)
                .MinimumLength(2)
                .NotNull().NotEmpty()
                .WithMessage("O campo nome é obrigatório ter no minimo duas letras");

            RuleFor(x => x.ValorPlanoDiario)
                .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorPlanoDiario)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.ValorDiariaKmControlado)
                .NotNull().WithMessage("O campo valor diaria Km controlador é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiariaKmControlado)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);


            RuleFor(x => x.ValorDiarioKmLivre)
                .NotNull().WithMessage("O campo valor diario Km livre é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiarioKmLivre)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
