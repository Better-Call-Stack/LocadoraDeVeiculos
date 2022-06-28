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

            /*RuleFor(x => x.Nome)
                 .Must((primeiro, segundo) => primeiro.Nome.Count(comparer => Equals(segundo)) == 1)
                 .WithMessage("Não pode haver nomes duplicados");*/

            //RuleFor(x => x.Nome).NotEqual(x => x.Nome);

            RuleFor(x => x.Nome)
                .MinimumLength(2).WithMessage("O campo nome é obrigatório ter no minimo duas letras")
                .NotNull().WithMessage("O campo nome é obrigatório ter no minimo duas letras")
                .NotEmpty().WithMessage("O campo nome é obrigatório ter no minimo duas letras");

            RuleFor(x => x.ValorPlanoDiario)
                .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorPlanoDiario)
                .NotNull().WithMessage("O campo Plano Diário deve ser maior que zero")
                .NotEmpty().WithMessage("O campo Plano Diário deve ser maior que zero")
                .GreaterThan(0).WithMessage("O campo Plano Diário deve ser maior que zero"); 

            RuleFor(x => x.ValorDiariaKmControlado)
                .NotNull().WithMessage("O campo valor diaria Km controlador é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiariaKmControlado)
                .NotNull().WithMessage("O campo Diária Km Controlado deve ser maior que zero")
                .NotEmpty().WithMessage("O campo Diária Km Controlado deve ser maior que zero")
                .GreaterThan(0).WithMessage("O campo Diária Km Controlado deve ser maior que zero");


            RuleFor(x => x.ValorDiarioKmLivre)
                .NotNull().WithMessage("O campo valor diario Km livre é obrigatório")
                .NotEmpty().WithMessage("O campo título é obrigatório");

            RuleFor(x => x.ValorDiarioKmLivre)
                .NotNull().WithMessage("O campo Diária Km Livre deve ser maior que zero")
                .NotEmpty().WithMessage("O campo Diária Km Controlado deve ser maior que zero")
                .GreaterThan(0).WithMessage("O campo Diária Km Controlado deve ser maior que zero");
        }
    }
}
