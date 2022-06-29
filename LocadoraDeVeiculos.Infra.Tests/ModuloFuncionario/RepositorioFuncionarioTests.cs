using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioTests
    {
        Funcionario funcionario;
        RepositorioFuncionario repositorio = new RepositorioFuncionario();

        public RepositorioFuncionarioTests()
        {
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");

            funcionario = new Funcionario();
            funcionario.Nome = "Teste";
            funcionario.CPF = "012547896512";
            funcionario.Salario = (Decimal)2500.25;
            funcionario.DataDeAdmissao = new DateTime(1998,04,25);
            funcionario.Login = "TesteLogin";
            funcionario.Senha = "SenhaTeste";
            funcionario.Perfil = PerfilEnum.Administrador;
        }

        [TestMethod]
        public void Deve_Inserir_Funcionario()
        {
            repositorio.Inserir(funcionario);

            Funcionario f = repositorio.SelecionarPorId(1);

            f.Should().NotBeNull().And.Be(funcionario);
        }

        [TestMethod]
        public void Deve_Editar_Funcionario()
        {
            repositorio.Inserir(funcionario);

            Funcionario funcionarioAtualizado = repositorio.SelecionarPorId(funcionario.Id);
            funcionarioAtualizado.Nome = "Sergio";
            funcionarioAtualizado.Login = "LoginDoSergio";

            //action
            repositorio.Editar(funcionarioAtualizado);

            //assert
            Funcionario f = repositorio.SelecionarPorId(funcionario.Id);

            f.Should().NotBeNull();
            f.Nome.Should().Be("Sergio");
            f.Login.Should().Be("LoginDoSergio");
            f.Salario.Should().Be((Decimal)2500.25);
            f.DataDeAdmissao.Should().Be(new DateTime(1998, 04, 25));
        }

        [TestMethod]
        public void Deve_Excluir_Funcionario()
        {
            repositorio.Inserir(funcionario);

            repositorio.Excluir(funcionario);

            repositorio.SelecionarTodos().Count().Should().Be(0);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos()
        {

            Funcionario f1 = new Funcionario();
            {
                f1.Nome = "Valdemar";
                f1.CPF = "012547896542";
                f1.Salario = (Decimal)1850.25;
                f1.DataDeAdmissao = new DateTime(1995,06,24);
                f1.Perfil = PerfilEnum.Supervisor;
                f1.Login = "ValdemarLogin";
                f1.Senha = "Vendedor10";
            }
            Funcionario f2 = new Funcionario();
            {
                f2.Nome = "Vandeco";
                f2.CPF = "657147569852";
                f2.Salario = (Decimal)2500.25;
                f2.DataDeAdmissao = new DateTime(2012, 12, 12);
                f2.Perfil = PerfilEnum.Vendedor;
                f2.Login = "VandecoDeco";
                f2.Senha = "SenhaJoia";
            }

            repositorio.Inserir(funcionario);
            repositorio.Inserir(f1);
            repositorio.Inserir(f2);

            List<Funcionario> l = repositorio.SelecionarTodos();

            l[1].Should().Be(f1);
            l.Count.Should().Be(3);
        }

    }
}
