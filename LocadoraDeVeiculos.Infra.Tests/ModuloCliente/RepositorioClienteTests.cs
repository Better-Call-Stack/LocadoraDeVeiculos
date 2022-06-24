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
            DB.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            cliente = new Cliente();
            cliente.Nome = "Teste";
            cliente.TipoPessoa = TipoPessoa.Juridica;
            cliente.CPF = "915156161";
            cliente.Endereco = "Teste";
            cliente.Email = "teste@gmail.com";
            cliente.CNH = "123123";
            cliente.Cidade = "Bonja";
            cliente.Telefone = "99934561236";


        }

        [TestMethod]
        public void Deve_Inserir_Cliente()
        {
            repositorio.Inserir(cliente);

            Cliente c = repositorio.SelecionarPorId(1);

            c.Should().NotBeNull().And.Be(cliente);

        }


    }
}
