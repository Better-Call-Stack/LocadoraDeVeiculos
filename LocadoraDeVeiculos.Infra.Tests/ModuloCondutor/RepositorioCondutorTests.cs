using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;


namespace LocadoraDeVeiculos.Infra.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTests
    {
        RepositorioCondutor repositorioCondutor = new RepositorioCondutor();
        RepositorioCliente repositorioCliente = new RepositorioCliente();

        Condutor condutor;
        Cliente cliente;
        public RepositorioCondutorTests()
        {
            Db.ExecutarSql("DELETE FROM TBCONDUTOR; DBCC CHECKIDENT (TBCONDUTOR, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            

            cliente = new Cliente()
            {
                Nome = "O Pedra",
                CPF = "222.222.222-22",
                Telefone = "13168865",
                TipoPessoa = TipoPessoa.Fisica,
                Cidade = "Capital Lageana",
                Endereco = "ddsadas",
                Email = "dnsdnosandas",


            };

            condutor = new Condutor();
            condutor.Nome = "Bandolero";
            condutor.CPF = "111.111.111-34";
            condutor.CNH = "315656";
            condutor.ValidadeCNH = new DateTime(2024,10,10);
            condutor.Endereco = "R. Redenção, 105";
            condutor.Email = "ElBandolero@gmail.com";
            condutor.Telefone = "11111111";
            condutor.Cidade = "NY";

            condutor.Cliente = cliente;

        }

        [TestMethod]
        public void Deve_Inserir_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);
       

            Condutor cEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            cEncontrado.Should().NotBeNull().And.Be(condutor);
        }
       
        [TestMethod]
        public void Deve_Editar_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            Condutor condutorAtualizado = repositorioCondutor.SelecionarPorId(condutor.Id);
            condutorAtualizado.Nome = "Braian";
            condutorAtualizado.Telefone = "(49) 9 9999-9999";
            condutorAtualizado.Email = "ehOBraian@gmail.com";
            condutorAtualizado.CPF = "000.000.000-00";
            condutorAtualizado.Cliente = cliente;
            condutorAtualizado.Endereco = "132";
            condutorAtualizado.CNH = "111111111111";
            condutorAtualizado.ValidadeCNH = new DateTime(2023, 10, 10);



            //action
            repositorioCondutor.Editar(condutorAtualizado);

            //assert
            Condutor cEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            cEncontrado.Should().NotBeNull();
            cEncontrado.Nome.Should().Be("Braian");
            cEncontrado.Email.Should().Be("ehOBraian@gmail.com");
            cEncontrado.Telefone.Should().Be("(49) 9 9999-9999");
        }

        [TestMethod]
        public void Deve_Excluir_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            repositorioCondutor.Excluir(condutor);

            repositorioCondutor.SelecionarTodos().Count().Should().Be(0);
        }
    }
}
