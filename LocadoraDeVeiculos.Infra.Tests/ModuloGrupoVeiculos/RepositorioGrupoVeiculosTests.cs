using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloGrupoVeiculos
{
    [TestClass]
    public class RepositorioGrupoVeiculosTests
    {
        GrupoDeVeiculos grupoVeiculos;
        RepositorioGrupoVeiculosEmBancoDados repositorio = new RepositorioGrupoVeiculosEmBancoDados();

        public RepositorioGrupoVeiculosTests()
        {
            Db.ExecutarSql("DELETE FROM TBGRUPOVEICULOS; DBCC CHECKIDENT (TBGRUPOVEICULOS, RESEED, 0)");

            grupoVeiculos = new GrupoDeVeiculos();
            grupoVeiculos.Nome = "Impala";

        }

        [TestMethod]
        public void Deve_Inserir_GrupoVeiculo()
        {
            repositorio.Inserir(grupoVeiculos);

            GrupoDeVeiculos gv = repositorio.SelecionarPorId(1);

            gv.Should().NotBeNull().And.Be(grupoVeiculos);

        }

        [TestMethod]
        public void Deve_Editar_GrupoVeiculo()
        {
            repositorio.Inserir(grupoVeiculos);

            GrupoDeVeiculos grupoEditado = repositorio.SelecionarPorId(grupoVeiculos.Id);
            grupoEditado.Nome = "Gol";


            //action
            repositorio.Editar(grupoEditado);

            //assert
            GrupoDeVeiculos gv = repositorio.SelecionarPorId(grupoVeiculos.Id);

            gv.Should().NotBeNull();
            gv.Nome.Should().Be("Gol");

        }

        [TestMethod]
        public void Deve_Excluir_GrupoVeiculo()
        {
            repositorio.Inserir(grupoVeiculos);

            repositorio.Excluir(grupoVeiculos);

            repositorio.SelecionarTodos().Count().Should().Be(0);
        }
    }
}
