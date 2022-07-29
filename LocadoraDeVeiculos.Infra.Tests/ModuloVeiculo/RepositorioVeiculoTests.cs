using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoTests
    {
        Veiculo veiculo;
        GrupoDeVeiculos gv;
        RepositorioVeiculo repositorioVeiculo = new RepositorioVeiculo();
        RepositorioGrupoVeiculos repositorioGrupoVeiculos = new RepositorioGrupoVeiculos();

        public RepositorioVeiculoTests()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO;");
            
            gv = new GrupoDeVeiculos();

            gv.Nome = "Entregador Tofu";

            veiculo = new Veiculo()
            {
                Modelo = "Deja vu",
                Fabricante = "Honda",
                Placa = "1234567",
                Cor = "White",
                TipoCombustivel = TipoCombustivelEnum.Gasolina,
                StatusVeiculo = StatusVeiculoEnum.Disponível,
                CapacidadeTanque = 1000,
                KmPercorrido = 8000,
                Grupo = gv,
                FotoVeiculo = new byte[] {}
            };

        }

        [TestMethod]
        public void Deve_Inserir_Veiculo()
        {
            repositorioGrupoVeiculos.Inserir(gv);
            repositorioVeiculo.Inserir(veiculo);

            Veiculo v = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            v.Should().NotBeNull().And.Be(veiculo);

        }

        [TestMethod]
        public void Deve_Editar_Veiculo()
        {
            repositorioGrupoVeiculos.Inserir(gv);
            repositorioVeiculo.Inserir(veiculo);

            Veiculo veiculoAtualizado = repositorioVeiculo.SelecionarPorId(veiculo.Id);
            veiculoAtualizado.Cor = "Preto";
            veiculoAtualizado.KmPercorrido = 0;
            veiculoAtualizado.Placa = "7654321";

            //action
            repositorioVeiculo.Editar(veiculoAtualizado);

            //assert
            Veiculo v = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            v.Should().NotBeNull();
            v.Cor.Should().Be("Preto");
            v.KmPercorrido.Should().Be(0);
            v.Placa.Should().Be("7654321");
        }

        [TestMethod]
        public void Deve_Excluir_Veiculo()
        {
            repositorioGrupoVeiculos.Inserir(gv);

            repositorioVeiculo.Inserir(veiculo);

            repositorioVeiculo.Excluir(veiculo);

            repositorioVeiculo.SelecionarTodos().Count().Should().Be(0);
        }

    }
    
}
