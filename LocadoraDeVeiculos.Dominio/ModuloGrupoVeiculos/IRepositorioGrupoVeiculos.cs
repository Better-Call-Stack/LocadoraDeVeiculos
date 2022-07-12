using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public interface IRepositorioGrupoVeiculos : Irepositorio<GrupoDeVeiculos>
    {
        GrupoDeVeiculos SelecionarGrupoVeiculosPorNome(string nome);

    }
}
