using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("O campo Nome é obrigatório")
                .NotEmpty().WithMessage("O campo Nome é obrigatório");


            When(x => x.TipoPessoa == TipoPessoa.Fisica, () =>

                 RuleFor(x => x.CPF).NotNull().WithMessage("O campo CPF é obrigatório para pessoa física")
                 .NotEmpty().WithMessage("O campo CPF é obrigatório para pessoa física")
                 );

            When(x => x.TipoPessoa == TipoPessoa.Juridica, () =>

                RuleFor(x => x.CNPJ).NotNull().WithMessage("O campo CNPJ é obrigatório para pessoa jurídica")
                .NotEmpty().WithMessage("O campo CNPJ é obrigatório para pessoa jurídica")
                );

            RuleFor(x => x.Cidade).NotNull().WithMessage("O campo Cidade é obrigatório")
                .NotEmpty().WithMessage("O campo Cidade é obrigatório");

            RuleFor(x => x.Endereco).NotNull().WithMessage("O campo Endereço é obrigatório")
                .NotEmpty().WithMessage("O campo Endereço é obrigatório");

            RuleFor(x => x.Telefone).NotNull().WithMessage("O campo Telefone é obrigatório")
                .NotEmpty().WithMessage("O campo Telefone é obrigatório");

        }
    }
}
