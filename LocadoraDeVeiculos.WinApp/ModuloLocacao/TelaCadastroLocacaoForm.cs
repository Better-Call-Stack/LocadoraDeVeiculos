using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
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
        private ServicoTaxa servicoTaxa;
             
        private Cliente cliente;
        private Veiculo veiculo;
        private GrupoDeVeiculos grupo;
        private PlanoDeCobranca plano;
        private List<Taxa> taxas;

        public TelaCadastroLocacaoForm(ServicoCliente servicoCliente, ServicoVeiculo servicoVeiculo,
            ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoCondutor servicoCondutor, ServicoPlanoDeCobranca servicoPlano)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;

            PovoarCbxGrupoVeiculos();
            AtualizarValoresPlano();
            PovoarTaxas();
            this.servicoCondutor = servicoCondutor;
            this.servicoPlano = servicoPlano;
        }

        private void PovoarTaxas()
        {
            var resultadoSelecao = servicoTaxa.SelecionarTodos();

            if (resultadoSelecao.IsSuccess)
            {
                foreach (var taxa in servicoTaxa.SelecionarTodos().Value)
                {
                    clbTaxas.Items.Add(taxa);
                }
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

                if(locacao.Cliente != null)
                {
                    txtCliente.Text = locacao.Cliente.Nome;
                    cliente = locacao.Cliente;

                    cbxCondutor.SelectedItem = locacao.Condutor;

                    cbxGrupoVeiculos.SelectedItem = locacao.Veiculo.Grupo;
                    AtualizarValoresPlano();

                    cbxPlanoCobranca.SelectedText = locacao.PlanoSelecionado;

                    int posicao = 0;
                    foreach (var taxaLocacao in locacao.Taxas)
                    {
                        foreach (var taxaLista in clbTaxas.Items)
                        {
                            if (taxaLocacao == taxaLista)
                                clbTaxas.SetItemChecked(posicao, true);

                            posicao++;
                        }
                    }

                    dpLocacao.Value = locacao.DataLocacao;
                    dpDevolucao.Value = locacao.PrevisaoDevolucao;
                }
                
          


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
            var resultadoSelecao = servicoCondutor.SelecionarTodos();

            if (resultadoSelecao.IsSuccess)
            {
                foreach (var c in servicoCondutor.SelecionarTodos().Value)
                {
                    if (c.Cliente.Id == cliente.Id)
                        cbxCondutor.Items.Add(c);
                }
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
                    plano = p;
            }
        }

        private void cbxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValoresPlano();
        }

        private void AtualizarValoresPlano()
        {

            switch (cbxPlanoCobranca.SelectedItem)
            {

                case "Diário":
                    txtDiaria.Text = plano.ValorPorDia_PlanoDiario.ToString();
                    txtKmRodado.Text = plano.ValorKmRodado_PlanoDiario.ToString();
                    txtKmLivre.Text = "0";
                    return;

                case "Km Controlado":
                    txtDiaria.Text = plano.ValorPorDia_PlanoKmControlado.ToString();
                    txtKmRodado.Text = plano.ValorKmRodado_PlanoKmControlado.ToString();
                    txtKmLivre.Text = plano.KmLivreIncluso_PlanoKmControlado.ToString();
                    return;

                case "Km Livre":
                    txtDiaria.Text = plano.ValorPorDia_PlanoKmLivre.ToString();
                    txtKmRodado.Text = "0";
                    txtKmLivre.Text = "0";
                    return;
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

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            locacao.Cliente = cliente;
            locacao.Condutor = (Condutor)cbxCondutor.SelectedItem;
            locacao.PlanoSelecionado = cbxPlanoCobranca.Text;
            locacao.Veiculo = veiculo;
            locacao.PlanoDeCobranca = plano;
            locacao.DataLocacao = dpLocacao.Value;
            locacao.PrevisaoDevolucao = dpDevolucao.Value;
            locacao.StatusLocacao = StatusLocacao.Aberta;




            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(erro, "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
