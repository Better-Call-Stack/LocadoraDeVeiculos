using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.GrupoVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;

namespace LocadoraDeVeiculos.WinApp
{
    public partial class TelaInicial : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;

        public TelaInicial()
        {
            InitializeComponent();

            labelTipoCadastro.Text = String.Empty;

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

            controladores.Add("Funcionários", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
            controladores.Add("Clientes", new ControladorCliente (servicoCliente));
            controladores.Add("Grupo de Veículos", new ControladorGrupoVeiculos(repositorioGrupoVeiculos, servicoGrupoVeiculos));
            controladores.Add("Planos de Cobrança", new ControladorPlanoDeCobranca(repositorioPlanoDeCobranca, servicoPlanoDeCobranca, repositorioGrupoVeiculos));
            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa, servicoTaxa));
            controladores.Add("Condutores", new ControladorCondutor(servicoCondutor, servicoCliente));
            controladores.Add("Veículos", new ControladorVeiculo(repositorioVeiculo, servicoVeiculo, repositorioGrupoVeiculos));
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarListagem();
             
            ConfigurarToolbox();
        }

        private void ConfigurarListagem()
        {

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {

            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void grupoVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }
    }
}
