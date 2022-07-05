using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("Nome é campo obrigatório")
                .NotEmpty().WithMessage("Nome é campo obrigatório");

            RuleFor(x => x.CNH).NotNull().WithMessage("CNH é campo obrigatório")
                .NotEmpty().WithMessage("CNH é campo obrigatório");

            RuleFor(x => x.CNH.ToCharArray().Length).Equal(12).WithMessage("CNH inválida");

            RuleFor(x => x.ValidadeCNH).NotNull().WithMessage("Validade CNH é campo obrigatório")
                .NotEmpty().WithMessage("Validade CNH é campo obrigatório");

            RuleFor(x => x.Cliente).NotNull().WithMessage("Campo Cliente é obrigatório")
                .NotEmpty().WithMessage("Campo Cliente é obrigatório");

            RuleFor(x => x.CPF).NotNull().WithMessage("Campo CPF é obrigatório")
              .NotEmpty().WithMessage("Campo CPF é obrigatório");

            RuleFor(x => x.CPF.ToCharArray().Length).Equal(14).WithMessage("CPF inválido");

            RuleFor(x => x.Telefone).NotNull().WithMessage("Campo Telefone é obrigatório")
              .NotEmpty().WithMessage("Campo Telefone é obrigatório");

            RuleFor(x => x.Telefone.ToCharArray().Length).Equal(16).WithMessage("Telefone inválido");

            RuleFor(x => x.Endereco).NotNull().WithMessage("Campo Endereço é obrigatório")
              .NotEmpty().WithMessage("Campo Endereço é obrigatório");
        }
    }
}
