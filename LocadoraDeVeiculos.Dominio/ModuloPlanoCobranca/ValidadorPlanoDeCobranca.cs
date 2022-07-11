using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.ValorKmRodado_PlanoDiario)
                    .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                    .NotEmpty().WithMessage("O campo valor plano diario é obrigatório");

            RuleFor(x => x.ValorPorDia_PlanoDiario)
                    .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                    .NotEmpty().WithMessage("O campo valor plano diario é obrigatório");

            RuleFor(x => x.ValorKmRodado_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.KmLivreIncluso_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.ValorPorDia_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.ValorPorDia_PlanoKmLivre)
                    .NotNull().WithMessage("O campo valor diario Km livre é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diario Km livre é obrigatório");

            RuleFor(x => x.GrupoDeVeiculos).NotNull().WithMessage("Selecione um Grupo de Veículos")
                .NotEmpty().WithMessage("Selecione um Grupo de Veículos");
        }

    }
}
