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

            RuleFor(x => x.Nome)
                .MinimumLength(2)
                .NotNull().NotEmpty()
                .WithMessage("O campo nome é obrigatório ter no minimo duas letras");

        }
    }
}
