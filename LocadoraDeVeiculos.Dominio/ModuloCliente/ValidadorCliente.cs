using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty();

            When(x => x.TipoPessoa == TipoPessoa.Fisica, () =>
            
                RuleFor(x => x.CNH).NotNull().NotEmpty()
                );
            
        }
    }
}
