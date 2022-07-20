using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.GrupoVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            InicializarControladores();
        }

        private void InicializarControladores()
        {
            var repositorioFuncionario = new RepositorioFuncionario();
            var repositorioCliente = new RepositorioCliente();
            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculos();
            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobranca();
            var repositorioTaxa = new RepositorioTaxa();
            var repositorioCondutor = new RepositorioCondutor();
            var repositorioVeiculo = new RepositorioVeiculo();

            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoGrupoVeiculos = new ServicoGrupoVeiculos(repositorioGrupoVeiculos);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));
            controladores.Add("ControladorGrupoVeiculos", new ControladorGrupoVeiculos(servicoGrupoVeiculos));
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(repositorioPlanoDeCobranca, servicoPlanoDeCobranca, repositorioGrupoVeiculos));
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculos));
        }

        internal ControladorBase Get<T>()
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return controladores[nomeControlador];
        }
    }
}
