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
            Db.ExecutarSql("DELETE FROM TBPLANODECOBRANCA; DBCC CHECKIDENT (TBPLANODECOBRANCA, RESEED, 0)");

            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS; DBCC CHECKIDENT (TBGRUPOVEICULOS, RESEED, 0)");

            grupoDeVeiculos = new GrupoDeVeiculos()
            {
                Nome = "Esportivo"
            };

            planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.txtValorPorDia_PlanoDiario = 120;
            planoDeCobranca.txtValorKmRodado_PlanoDiario = 130;
            planoDeCobranca.txtValorPorDia_PlanoKmControlado = 280;
            planoDeCobranca.txtValorKmRodado_PlanoKmControlado = 120;
            planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado = 190;
            planoDeCobranca.txtValorPorDia_PlanoKmLivre = 350;

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
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoDiario = 100;
            planoDeCobrancaAtualizado.txtValorKmRodado_PlanoDiario = 120;
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoKmControlado = 250;
            planoDeCobrancaAtualizado.txtValorKmRodado_PlanoKmControlado = 150;
            planoDeCobrancaAtualizado.txtKmLivreIncluso_PlanoKmControlado = 180;
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoKmLivre = 300;

            //action
            repositorioplanoDeCobranca.Editar(planoDeCobrancaAtualizado);

            //assert
            PlanoDeCobranca pc = repositorioplanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            pc.Should().NotBeNull();
            pc.txtValorPorDia_PlanoDiario.Should().Be(100);
            pc.txtValorKmRodado_PlanoDiario.Should().Be(120);
            pc.txtValorPorDia_PlanoKmControlado.Should().Be(250);
            pc.txtValorKmRodado_PlanoKmControlado.Should().Be(150);
            pc.txtKmLivreIncluso_PlanoKmControlado.Should().Be(180);
            pc.txtValorPorDia_PlanoKmLivre.Should().Be(300);
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
