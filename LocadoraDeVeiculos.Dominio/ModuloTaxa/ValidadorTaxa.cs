using FluentValidation;

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

        }
    }
}
