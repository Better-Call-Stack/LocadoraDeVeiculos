﻿using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.GrupoVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var repositorioGrupoVeiculos = new RepositorioGrupoVeiculosEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Funcionários", new ControladorFuncionario(repositorioFuncionario));
            controladores.Add("Clientes", new ControladorCliente(repositorioCliente));
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

        }

        private void grupoVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taxasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
