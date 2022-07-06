using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteTests
    {
        Cliente cliente;
        RepositorioCliente repositorio = new RepositorioCliente();
       
        public RepositorioClienteTests()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            cliente = new Cliente();
            cliente.Nome = "Teste";
            cliente.TipoPessoa = TipoPessoa.Juridica;
            cliente.CNPJ = "915156161";
            cliente.Endereco = "Teste";
            cliente.Email = "teste@gmail.com";
            cliente.Cidade = "Bonja";
            cliente.Telefone = "99934561236";


        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {
            repositorio.Inserir(cliente);

            Cliente c = repositorio.SelecionarPorId(cliente.Id);

            c.Should().NotBeNull().And.Be(cliente);

        }

        [TestMethod]
        public void Deve_Editar_Cliente()
        {
            repositorio.Inserir(cliente);

            Cliente clienteAtualizado = repositorio.SelecionarPorId(cliente.Id);
            clienteAtualizado.Nome = "Marcello";
            clienteAtualizado.Telefone = "515615616";

            //action
            repositorio.Editar(clienteAtualizado);

            //assert
            Cliente c = repositorio.SelecionarPorId(cliente.Id);

            c.Should().NotBeNull();
            c.Nome.Should().Be("Marcello");
            c.Endereco.Should().Be("Teste");
            c.Telefone.Should().Be("515615616");
        }

        [TestMethod]
        public void Deve_Excluir_Cliente()
        {
            repositorio.Inserir(cliente);

            repositorio.Excluir(cliente);

            repositorio.SelecionarTodos().Count().Should().Be(0);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos()
        {
           
            Cliente c1 = new Cliente();
            {
                c1.Nome = "Jimmy";
                c1.TipoPessoa = TipoPessoa.Fisica;
                c1.CPF = "915156161";
                c1.Endereco = "Teste";
                c1.Email = "teste@gmail.com";
                c1.Cidade = "Bonja";
                c1.Telefone = "99934561236";
            }
            Cliente c2 = new Cliente();
            {
                c2.Nome = "Neutro";
                c2.TipoPessoa = TipoPessoa.Fisica;
                c2.CPF = "14655";
                c2.Endereco = "Teste";
                c2.Email = "teste@gmail.com";
                c2.Cidade = "Bonja";
                c2.Telefone = "99934561236";
            }

            repositorio.Inserir(cliente);
            repositorio.Inserir(c1);
            repositorio.Inserir(c2);

            List<Cliente> l = repositorio.SelecionarTodos();

            l[1].Should().Be(c1);
            l.Count.Should().Be(3);
        }
    }
}
