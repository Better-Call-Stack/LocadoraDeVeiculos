using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private RepositorioVeiculo repositorioVeiculo;
        private ValidadorVeiculo validadorVeiculo;

        public ServicoVeiculo(RepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo=repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Veiculo veiculo)
        {
            repositorioVeiculo.Excluir(veiculo);

            return new ValidationResult();
        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            validadorVeiculo = new ValidadorVeiculo();

            var resultadoValidacao = validadorVeiculo.Validate(veiculo);

            if (PlacaDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa já cadastrada."));

            return resultadoValidacao;
        }

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
