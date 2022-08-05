using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloOrm;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.GrupoVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraDeVeiculos.WinApp.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Config;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void InicializarControladores()
        {
            var config = new ConfiguracaoAplicacaoLocadora();

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(config);

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculosOrm(contextoDadosOrm);
            var repositorioPlanoDeCobranca = new RepositorioPlanoCobrancaOrm(contextoDadosOrm);
            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            var repositorioDevolucao = new RepositorioDevolucaoOrm(contextoDadosOrm);


            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            var servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca, contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm);
            var servicoDevolucao = new ServicoDevolucao(repositorioDevolucao, contextoDadosOrm);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));
            controladores.Add("ControladorGrupoVeiculos", new ControladorGrupoVeiculos(servicoGrupoVeiculos));
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca, servicoGrupoVeiculos));
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculos));
            controladores.Add("ControladorLocacao", new ControladorLocacao(servicoLocacao, servicoCliente, servicoVeiculo, 
                servicoGrupoVeiculos, servicoCondutor, servicoPlanoDeCobranca, servicoTaxa));
            controladores.Add("ControladorDevolucao", new ControladorDevolucao(servicoDevolucao, servicoLocacao, servicoTaxa));
        }

        
    }
}
