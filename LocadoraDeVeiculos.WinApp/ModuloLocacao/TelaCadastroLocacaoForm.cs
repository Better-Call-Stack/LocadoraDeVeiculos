using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private ServicoCliente servicoCliente;
        private ServicoVeiculo servicoVeiculo;
        private ServicoCondutor servicoCondutor;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        private ServicoPlanoDeCobranca servicoPlano;
             
        private Cliente cliente;
        private Veiculo veiculo;
        private GrupoDeVeiculos grupo;
        private PlanoDeCobranca plano;

        public TelaCadastroLocacaoForm(ServicoCliente servicoCliente, ServicoVeiculo servicoVeiculo, 
            ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;

            PovoarCbxGrupoVeiculos();
            AtualizarValoresPlano();
        }

        private void AtualizarValoresPlano()
        {
            if(cbxPlanoCobranca.SelectedItem == "Diário")
            {
             //   txtDiaria.Text =     ///////////////////////////////////////GRUPO VEICULO PRECISA DE PLANO 
            }
                
        }

        private void PovoarCbxGrupoVeiculos()
        {
            var grupos = servicoGrupoVeiculos.SelecionarTodos().Value;

            if (grupos.Any()) 
                btnSelecionarVeiculo.Enabled = true;

            foreach (var grupo in grupos)
            {
                cbxGrupoVeiculos.Items.Add(grupo);
            }
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        private Locacao locacao;

        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                txtCliente.Text = locacao.Cliente.Nome;
                cliente = locacao.Cliente;
                
                cbxCondutor.SelectedItem = locacao.Condutor;
                
                cbxGrupoVeiculos.SelectedItem = locacao.Veiculo.Grupo;


            }


        }

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            BotaoSelecionarForm tela = new BotaoSelecionarForm(servicoCliente);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.Cancel)
                return;

            if(resultado == DialogResult.OK)
            {
                cliente = tela.cliente;
                txtCliente.Text = cliente.Nome;
                cbxCondutor.Enabled = true;
                PovoarCbxCondutor();
            }
        }

        private void PovoarCbxCondutor()
        {
            foreach (var c in servicoCondutor.SelecionarTodos().Value)
            {
                if(c.Cliente.Id == cliente.Id)
                cbxCondutor.Items.Add(c);
            }
        }

        private void btnSelecionarVeiculo_Click(object sender, EventArgs e)
        {
            BotaoSelecionarForm tela = new BotaoSelecionarForm(servicoVeiculo, servicoGrupoVeiculos, grupo);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.Cancel)
                return;

            if (resultado == DialogResult.OK)
            {
                veiculo = tela.veiculo;
                txtVeiculo.Text = veiculo.Modelo;
            }
        }

        private void cbxGrupoVeiculos_SelectedValueChanged(object sender, EventArgs e)
        {
             grupo = (GrupoDeVeiculos)cbxGrupoVeiculos.SelectedItem;
             txtVeiculo.Text = "";
             veiculo = null;

            ObtemPlanoCobranca();
        }

        private void ObtemPlanoCobranca()
        {
            foreach (var p in servicoPlano.SelecionarTodos().Value)
            {
                if (p.GrupoDeVeiculos == grupo)
                    grupo = p.GrupoDeVeiculos;
            }
        }

        private void cbxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
