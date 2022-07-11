using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
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
        RepositorioPlanoDeCobranca repositorio = new RepositorioPlanoDeCobranca();

        public RepositorioPlanoDeCobrancaTests()
        {
            Db.ExecutarSql("DELETE FROM TBPLANODECOBRANCA; DBCC CHECKIDENT (TBPLANODECOBRANCA, RESEED, 0)");

            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS; DBCC CHECKIDENT (TBGRUPOVEICULOS, RESEED, 0)");


            planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.txtValorPorDia_PlanoDiario = 120;
            planoDeCobranca.txtValorKmRodado_PlanoDiario = 130;
            planoDeCobranca.txtValorPorDia_PlanoKmControlado = 280;
            planoDeCobranca.txtValorKmRodado_PlanoKmControlado = 120;
            planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado = 190;
            planoDeCobranca.txtValorPorDia_PlanoKmLivre = 350;
        }

        [TestMethod]
        public void Deve_Inserir_PlanoDeCobranca()
        {
            repositorio.Inserir(planoDeCobranca);

            PlanoDeCobranca pc = repositorio.SelecionarPorId(planoDeCobranca.Id);

            pc.Should().NotBeNull().And.Be(planoDeCobranca);
        }

        [TestMethod]
        public void Deve_Editar_PlanoDeCobranca()
        {
            repositorio.Inserir(planoDeCobranca);

            PlanoDeCobranca planoDeCobrancaAtualizado = repositorio.SelecionarPorId(planoDeCobranca.Id);
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoDiario = 100;
            planoDeCobrancaAtualizado.txtValorKmRodado_PlanoDiario = 120;
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoKmControlado = 250;
            planoDeCobrancaAtualizado.txtValorKmRodado_PlanoKmControlado = 150;
            planoDeCobrancaAtualizado.txtKmLivreIncluso_PlanoKmControlado = 180;
            planoDeCobrancaAtualizado.txtValorPorDia_PlanoKmLivre = 300;

            //action
            repositorio.Editar(planoDeCobrancaAtualizado);

            //assert
            PlanoDeCobranca pc = repositorio.SelecionarPorId(planoDeCobranca.Id);

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
            repositorio.Inserir(planoDeCobranca);

            repositorio.Excluir(planoDeCobranca);

            repositorio.SelecionarTodos().Count().Should().Be(0);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos()
        {

            PlanoDeCobranca pc1 = new PlanoDeCobranca();
            {
                pc1.txtValorPorDia_PlanoDiario = 90;
                pc1.txtValorKmRodado_PlanoDiario = 140;
                pc1.txtValorPorDia_PlanoKmControlado = 270;
                pc1.txtValorKmRodado_PlanoKmControlado = 170;
                pc1.txtKmLivreIncluso_PlanoKmControlado = 150;
                pc1.txtValorPorDia_PlanoKmLivre = 250;
            }
            PlanoDeCobranca pc2 = new PlanoDeCobranca();
            {
                pc2.txtValorPorDia_PlanoDiario = 85;
                pc2.txtValorKmRodado_PlanoDiario = 154;
                pc2.txtValorPorDia_PlanoKmControlado = 240;
                pc2.txtValorKmRodado_PlanoKmControlado = 190;
                pc2.txtKmLivreIncluso_PlanoKmControlado = 170;
                pc2.txtValorPorDia_PlanoKmLivre = 280;
            }

            repositorio.Inserir(planoDeCobranca);
            repositorio.Inserir(pc1);
            repositorio.Inserir(pc2);

            List<PlanoDeCobranca> p = repositorio.SelecionarTodos();

            p[1].Should().Be(pc1);
            p.Count.Should().Be(3);
        }
    }
}
