using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {

        ServicoLocacao servicoLocacao;
        ServicoTaxa servicoTaxa;
        private List<Taxa> taxas = new List<Taxa>();

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa, Locacao locacao)
        {
            InitializeComponent();

            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
            this.locacao = locacao;

            txtValorTotal.Text = locacao.Subtotal.ToString();
            dpPrevisao.Value = locacao.PrevisaoDevolucao;
            comboBoxVolumeTanque.SelectedIndex = 4;

            CarregarTaxas();
            CarregarLocacao();
            AtualizarTotal();
        }

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa)
        {
            InitializeComponent();

            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;

            txtValorTotal.Text = locacao.Subtotal.ToString();
            dpPrevisao.Value = locacao.PrevisaoDevolucao;
            comboBoxVolumeTanque.SelectedIndex = 4;

            CarregarTaxas();
            CarregarLocacao();
            AtualizarTotal();
        }

        private Devolucao devolucao;
        private Locacao locacao;

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }

        public Devolucao Devolucao
        {
            get { return Devolucao; }
            set
            {
                devolucao = value;

                if (devolucao.Locacao != null)
                {
                    comboBoxVolumeTanque.SelectedItem = devolucao.VolumeTanque;
                    dpDevolucao.Value = devolucao.DataDevolucao;
                    txtQuilometragem.Text = devolucao.Quilometragem.ToString();
                    txtValorGasolina.Text = devolucao.ValorCombustivel.ToString();

                    int posicao = 0;
                    foreach (var taxa in devolucao.Taxas)
                    {
                        for (int j = 0; j < cklistTaxas.Items.Count; j++)
                        {
                            if (taxa == cklistTaxas.Items[j])
                            {
                                cklistTaxas.SetItemChecked(posicao, true);
                            }
                            posicao++;
                        }
                        posicao = 0;
                    }
                }
            }
        }


        public void CarregarTaxas()
        {
            var resultadoSelecao = servicoTaxa.SelecionarTodos();

            if (resultadoSelecao.IsSuccess)
            {
                List<Taxa> taxas = servicoTaxa.SelecionarTodos().Value;

                foreach (var taxa in taxas)
                {
                    if (!locacao.Taxas.Contains(taxa))
                    {
                        if (taxa.Tipo == TipoCalculoTaxa.Fixo)
                            cklistTaxas.Items.Add(taxa);
                    }
                }
            }
        }

        private void CarregarLocacao()
        {
            txtCliente.Text = locacao.Cliente.Nome;
            txtCondutor.Text = locacao.Condutor.Nome;
            txtVeiculo.Text = locacao.Veiculo.Modelo;
            txtPlano.Text = locacao.PlanoSelecionado;
        }


        private void AtualizarTotal()
        {
            double total = 0;

            decimal ValorTaxas = CalculaValorTaxas();

            decimal totalGasolina = CalculaTotalGasolina();

            decimal subtotal = CalculaSubtotal();

            decimal totalValorQuilometros = CalculaValorKms();

            total = Convert.ToDouble(ValorTaxas + totalGasolina + subtotal + totalValorQuilometros);

            TimeSpan diasAhMais = dpDevolucao.Value.Date - locacao.PrevisaoDevolucao.Date;

            if (diasAhMais.Days > 0)
            {
                total += total * 0.1;
            }

            txtValorTotal.Text = total.ToString();
        }


        private decimal CalculaSubtotal()
        {
            decimal subtotal = 0;

            TimeSpan diasAhMais = dpDevolucao.Value.Date - locacao.PrevisaoDevolucao.Date;

            if (diasAhMais.Days > 0)
                subtotal = locacao.Subtotal + (locacao.ValorDiario * diasAhMais.Days);
            else
                subtotal = locacao.Subtotal;

            return subtotal;
        }

        private decimal CalculaValorTaxas()
        {
            decimal ValorTaxas = 0;
            foreach (Taxa item in cklistTaxas.CheckedItems)
            {
                ValorTaxas += item.Valor;
            }

            return ValorTaxas;
        }

        private decimal CalculaValorKms()
        {
            decimal kmsRodados = txtQuilometragem.Value;
            decimal totalValorQuilometros = 0;

            switch (txtPlano.Text)
            {
                case "Diário":
                    totalValorQuilometros = kmsRodados * locacao.PlanoDeCobranca.ValorKmRodado_PlanoDiario;
                    break;

                case "Km Controlado":

                    decimal quantidadeQuilometrosParaPagar = kmsRodados - locacao.PlanoDeCobranca.KmLivreIncluso_PlanoKmControlado;

                    if (quantidadeQuilometrosParaPagar > 0)
                        totalValorQuilometros = quantidadeQuilometrosParaPagar * locacao.PlanoDeCobranca.ValorKmRodado_PlanoKmControlado;
                    else
                        totalValorQuilometros = 0;
                    break;

                case "Km Livre":
                    totalValorQuilometros = 0;
                    break;
            }

            return totalValorQuilometros;
        }

        private decimal CalculaTotalGasolina()
        {
            double capacidadeTanque = (double)locacao.Veiculo.CapacidadeTanque;

            double valorGasolina = Double.Parse(txtValorGasolina.Text);

            double total = 0;

            switch (comboBoxVolumeTanque.SelectedItem)
            {
                case "Vazio":
                    total = valorGasolina * capacidadeTanque;
                    break;

                case "2/5":
                    total = valorGasolina * (capacidadeTanque * (3.0 / 5.0));
                    break;

                case "Meio":
                    total = valorGasolina * (capacidadeTanque / 2);
                    break;

                case "4/5":
                    total = valorGasolina * (capacidadeTanque * (1.0 / 5.0));
                    break;

                case "Cheio":
                    total = 0;
                    break;
            }
            txtValorTotalGasolina.Text = total.ToString();

            return Convert.ToDecimal(total);
        }



        private void comboBoxVolumeTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal total = CalculaTotalGasolina();

            txtValorTotalGasolina.Text = total.ToString();

            AtualizarTotal();
        }

        private void cklistTaxas_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizarTotal();
        }

        private void txtQuilometragem_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotal();
        }

        private void txtValorGasolina_ValueChanged(object sender, EventArgs e)
        {
            AtualizarTotal();
        }

        private void DataDevolucao_ValueChanged(object sender, EventArgs e)
        {
            if(dpDevolucao.Value < locacao.DataLocacao)
            {
                MessageBox.Show("Data de devolução não pode ser menor do que a data de locação", "Inserção de devolução",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                dpDevolucao.Value = DateTime.Now;

                return;
            }

            AtualizarTotal();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            devolucao.VolumeTanque = comboBoxVolumeTanque.SelectedItem.ToString();
            devolucao.DataDevolucao = dpDevolucao.Value;
            devolucao.ValorCombustivel = txtValorGasolina.Value;
            devolucao.Quilometragem = txtQuilometragem.Value;
            devolucao.Valor = Convert.ToDecimal(txtValorTotal.Text);
            devolucao.Locacao = locacao;

            foreach (Taxa taxa in cklistTaxas.CheckedItems)
            {
                taxas.Add(taxa);
            }
            devolucao.Taxas = taxas;

            var resultadoValidacao = GravarRegistro(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(erro, "Inserção devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }
                return;
            }
            devolucao.Locacao.StatusLocacao = StatusLocacao.Fechada;
            locacao.Veiculo.StatusVeiculo = Dominio.ModuloVeiculo.StatusVeiculoEnum.Disponível;
        }
    }
}
