using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloTaxa
{
    [TestClass]
    public class RepositorioTaxaTests
    {
      
            Taxa taxa;
            RepositorioTaxa repositorio = new RepositorioTaxa();

            public RepositorioTaxaTests()
            {
                Db.ExecutarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBTAXA, RESEED, 0)");

                taxa = new Taxa();
                taxa.Nome = "Cadeira Bebe";
                taxa.Valor = (decimal)25.5;
                taxa.Tipo = TipoCalculoTaxa.Diario;


            }

            [TestMethod]
            public void Deve_Inserir_Taxa()
            {
                repositorio.Inserir(taxa);

                Taxa t = repositorio.SelecionarPorId(1);

                t.Should().NotBeNull().And.Be(taxa);

            }

            [TestMethod]
            public void Deve_Editar_Cliente()
            {
                repositorio.Inserir(taxa);

                Taxa taxaAtualizada = repositorio.SelecionarPorId(taxa.Id);
                taxaAtualizada.Nome = "Lavação";
                taxaAtualizada.Tipo = TipoCalculoTaxa.Fixo;
                taxaAtualizada.Valor = (decimal)30.0;

                //action
                repositorio.Editar(taxaAtualizada);

                //assert
                Taxa t = repositorio.SelecionarPorId(taxa.Id);

                t.Should().NotBeNull();
                t.Nome.Should().Be("Lavação");
                t.Valor.Should().Be(30);
                t.Tipo.Should().Be(TipoCalculoTaxa.Fixo);
            }

            [TestMethod]
            public void Deve_Excluir_Cliente()
            {
                repositorio.Inserir(taxa);

                repositorio.Excluir(taxa);

                repositorio.SelecionarTodos().Count().Should().Be(0);
            }
    }
}


