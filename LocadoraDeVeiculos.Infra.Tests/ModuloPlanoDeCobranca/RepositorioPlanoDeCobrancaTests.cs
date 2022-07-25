using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaTests
    {
        PlanoDeCobranca planoDeCobranca;
        GrupoDeVeiculos grupoDeVeiculos;
        RepositorioPlanoDeCobranca repositorioplanoDeCobranca = new RepositorioPlanoDeCobranca();
        RepositorioGrupoVeiculos repositorioGrupoVeiculos = new RepositorioGrupoVeiculos();

        public RepositorioPlanoDeCobrancaTests()
        {
          //Db.ExecutarSql("DELETE FROM TBVEICULO;");
            Db.ExecutarSql("DELETE FROM TBPLANODECOBRANCA;");

            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS;");

            grupoDeVeiculos = new GrupoDeVeiculos()
            {
                Nome = "Esportivo"
            };

            planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.ValorPorDia_PlanoDiario = 120;
            planoDeCobranca.ValorKmRodado_PlanoDiario = 130;
            planoDeCobranca.ValorPorDia_PlanoKmControlado = 280;
            planoDeCobranca.ValorKmRodado_PlanoKmControlado = 120;
            planoDeCobranca.KmLivreIncluso_PlanoKmControlado = 190;
            planoDeCobranca.ValorPorDia_PlanoKmLivre = 350;

            planoDeCobranca.GrupoDeVeiculos = grupoDeVeiculos;
        }

        [TestMethod]
        public void Deve_Inserir_PlanoDeCobranca()
        {
            repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);
            repositorioplanoDeCobranca.Inserir(planoDeCobranca);

            PlanoDeCobranca pc = repositorioplanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            pc.Should().NotBeNull().And.Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_Editar_PlanoDeCobranca()
        {
            repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);
            repositorioplanoDeCobranca.Inserir(planoDeCobranca);

            PlanoDeCobranca planoDeCobrancaAtualizado = repositorioplanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);
            planoDeCobrancaAtualizado.ValorPorDia_PlanoDiario = 100;
            planoDeCobrancaAtualizado.ValorKmRodado_PlanoDiario = 120;
            planoDeCobrancaAtualizado.ValorPorDia_PlanoKmControlado = 250;
            planoDeCobrancaAtualizado.ValorKmRodado_PlanoKmControlado = 150;
            planoDeCobrancaAtualizado.KmLivreIncluso_PlanoKmControlado = 180;
            planoDeCobrancaAtualizado.ValorPorDia_PlanoKmLivre = 300;
            planoDeCobrancaAtualizado.GrupoDeVeiculos = grupoDeVeiculos;

            //action
            repositorioplanoDeCobranca.Editar(planoDeCobrancaAtualizado);

            //assert
            PlanoDeCobranca pc = repositorioplanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            pc.Should().NotBeNull();
            pc.ValorPorDia_PlanoDiario.Should().Be(100);
            pc.ValorKmRodado_PlanoDiario.Should().Be(120);
            pc.ValorPorDia_PlanoKmControlado.Should().Be(250);
            pc.ValorKmRodado_PlanoKmControlado.Should().Be(150);
            pc.KmLivreIncluso_PlanoKmControlado.Should().Be(180);
            pc.ValorPorDia_PlanoKmLivre.Should().Be(300);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoDeCobranca()
        {
            repositorioGrupoVeiculos.Inserir(grupoDeVeiculos);
            repositorioplanoDeCobranca.Inserir(planoDeCobranca);

            repositorioplanoDeCobranca.Excluir(planoDeCobranca);

            repositorioplanoDeCobranca.SelecionarTodos().Count().Should().Be(0);
        }
    }
}
