using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Placa)
               .Length(7)
               .NotNull().NotEmpty();

            RuleFor(x => x.Modelo)
                .NotNull().NotEmpty();

            RuleFor(x => x.Fabricante)
                 .NotNull().NotEmpty();

            RuleFor(x => x.CapacidadeTanque)
                .NotNull().NotEmpty();

            RuleFor(x => x.Ano)
                .GreaterThan(2000)
                .NotNull().NotEmpty();
        }
    }
}
