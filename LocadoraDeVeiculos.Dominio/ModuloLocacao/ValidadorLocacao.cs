using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Cliente).NotNull().WithMessage("Selecione um cliente")
                .NotEmpty().WithMessage("Selecione um cliente");
            
            RuleFor(x => x.Condutor).NotNull().WithMessage("Selecione um condutor")
                .NotEmpty().WithMessage("Selecione um condutor");

            RuleFor(x => x.Veiculo).NotNull().WithMessage("Selecione um veículo")
              .NotEmpty().WithMessage("Selecione um veículo");

            RuleFor(x => x.PlanoSelecionado).NotNull().WithMessage("Selecione um plano de cobrança")
             .NotEmpty().WithMessage("Selecione um  plano de cobrança");

            RuleFor(x => x.Condutor.ValidadeCNH).GreaterThan(DateTime.Now).WithMessage("CNH Vencida");

        }
    }
}
