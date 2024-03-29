﻿using FluentValidation;

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
                .MinimumLength(2).WithMessage("O campo nome é obrigatório ter no minimo duas letras")
                .NotNull().WithMessage("O campo nome é obrigatório ter no minimo duas letras")
                .NotEmpty().WithMessage("O campo nome é obrigatório ter no minimo duas letras");

        }
    }
}
