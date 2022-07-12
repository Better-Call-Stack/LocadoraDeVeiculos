using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Placa)
                .Length(7).WithMessage("Placa deve ter 7 caracteres.");
               
            RuleFor(x => x.Modelo)
                .NotNull().WithMessage("Digite um modelo.")
                .NotEmpty().WithMessage("Digite um modelo.");

            RuleFor(x => x.Fabricante)
                .NotNull().WithMessage("Digite um fabricante.")
                .NotEmpty().WithMessage("Digite um fabricante.");


            RuleFor(x => x.CapacidadeTanque)
                .NotNull().WithMessage("Cadastre um valor para a capacidade do tanque.")
                .NotEmpty().WithMessage("Cadastre um valor para a capacidade do tanque.");

            RuleFor(x => x.Ano)
                .GreaterThan(1999).WithMessage("Ano deve ser maior que 2000.")
                .NotNull().NotEmpty();

            RuleFor(x => x.StatusVeiculo)
               .NotNull().WithMessage("Selecione um status para o veículo.");

            RuleFor(x => x.Cor)
                .NotNull().WithMessage("Cadastre uma cor para o veículo.")
                .NotEmpty().WithMessage("Cadastre uma cor para o veículo.");

            RuleFor(x => x.TipoCombustivel)
                .NotNull().WithMessage("Selecione um tipo de combustível para o veículo.");

            RuleFor(x => x.Grupo)
                .NotNull().WithMessage("Selecione um grupo para o veículo.")
                .NotEmpty().WithMessage("Selecione um grupo para o veículo.");

        }
    }
}
