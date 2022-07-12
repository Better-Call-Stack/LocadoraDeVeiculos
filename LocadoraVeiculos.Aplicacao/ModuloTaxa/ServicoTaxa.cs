using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {

        private RepositorioTaxa repositorio;
        private ValidadorTaxa validador;

        public ServicoTaxa(RepositorioTaxa repositorio)
        {
            this.repositorio = repositorio;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorio.Inserir(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            var resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
                repositorio.Editar(taxa);

            return resultadoValidacao;
        }

        public ValidationResult Validar(Taxa taxa)
        {
            validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("NOME", "Nome Duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {

            var taxaEncontrada = repositorio.SelecionarTaxaPorNome(taxa.Nome);

            return taxaEncontrada != null &&
                   taxaEncontrada.Nome == taxa.Nome &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
