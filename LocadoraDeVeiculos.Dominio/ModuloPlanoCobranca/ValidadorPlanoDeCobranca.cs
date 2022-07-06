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
            RuleFor(x => x.txtValorKmRodado_PlanoDiario)
                    .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                    .NotEmpty().WithMessage("O campo valor plano diario é obrigatório");

            RuleFor(x => x.txtValorPorDia_PlanoDiario)
                    .NotNull().WithMessage("O campo valor plano diario é obrigatório")
                    .NotEmpty().WithMessage("O campo valor plano diario é obrigatório");

            RuleFor(x => x.txtValorKmRodado_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.txtKmLivreIncluso_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.txtValorPorDia_PlanoKmControlado)
                    .NotNull().WithMessage("O campo valor diaria Km controlado é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diaria Km controlado é obrigatório");

            RuleFor(x => x.txtValorPorDia_PlanoKmLivre)
                    .NotNull().WithMessage("O campo valor diario Km livre é obrigatório")
                    .NotEmpty().WithMessage("O campo valor diario Km livre é obrigatório");
        }

    }
}
