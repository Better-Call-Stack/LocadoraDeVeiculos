using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            RuleFor(x => x.ValorGasolina)
                .NotEmpty().WithMessage("O campo valor da gasolina é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor inválido");

            RuleFor(x => x.Quilometragem)
                .NotEmpty().WithMessage("O campo quilometragem é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor inválido");

            RuleFor(x => x.DataDevolucao)
                .NotEqual(DateTime.Today).WithMessage("A data de devolução não pode ser menor que o dia de hoje");

            RuleFor(x => x.volumeTanque)
                .NotNull().WithMessage("O campo volume do tanque deve ser adicionado");
        }
    }
}
