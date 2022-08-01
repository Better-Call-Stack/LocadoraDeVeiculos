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

            CarregarTaxas();
            AtualizarTotal();
            CarregarLocacao();

        }

        private Devolucao devolucao;
        private Locacao locacao;

        public Func<Devolucao, Result<Devolucao>> GravarRegistro { get; set; }
        public Func<Locacao, Result<Locacao>> LocacaoRegistro { get; set; }

        public Devolucao Devolucao
        {
            get { return Devolucao; }
            set 
            { 
                devolucao = value; 

                if(devolucao.Locacao != null)
                {
                    comboBoxVolumeTanque.SelectedItem = devolucao.VolumeTanque;
                    DataDevolucao.Value = devolucao.DataDevolucao;
                    txtQuilometragem.Text = devolucao.Quilometragem.ToString();
                    txtValorGasolina.Text = devolucao.ValorGasolina.ToString();

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

        public Locacao Locacao
        {
            get => locacao;
            set
            {
                locacao = value;
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
                        if (taxa.Tipo == TipoCalculoTaxa.Diario)
                            cklistTaxas.Items.Add(taxa);
                    }
                }
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
            decimal total = 0;

            decimal ValorTaxas = 0;
            foreach (Taxa item in cklistTaxas.CheckedItems)
            {
                ValorTaxas += item.Valor;
            }

            decimal totalGasolina = (decimal)txtValorGasolina.Value * CalculaQuantidadeGasolinaFaltando();

            
            TimeSpan diasAhMais = DataDevolucao.Value.Date - locacao.PrevisaoDevolucao.Date;

            decimal subtotal = locacao.Subtotal + (locacao.ValorDiario * diasAhMais.Days);

            total = ValorTaxas + totalGasolina + subtotal;

            if (diasAhMais.Days > 0)
            {
                total *= (10 / 100);
            }

            txtValorTotal.Text = total.ToString();
        }

        private void comboBoxVolumeTanque_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal total = CalculaQuantidadeGasolinaFaltando();

            txtValorTotalGasolina.Text = total.ToString();

            AtualizarTotal();
        }

        private decimal CalculaQuantidadeGasolinaFaltando()
        {
            decimal capacidadeTanque = Locacao.Veiculo.CapacidadeTanque;

            decimal valorGasolina = Decimal.Parse(txtValorGasolina.Text);

            decimal total = 0;

            switch (comboBoxVolumeTanque.SelectedItem)
            {
                case "Vazio":
                    total = valorGasolina * capacidadeTanque;
                    break;

                case "2/5":
                    total = valorGasolina * (capacidadeTanque * (3 / 5));
                    break;

                case "Meio":
                    total = valorGasolina * (capacidadeTanque / 2);
                    break;

                case "4/5":
                    total = valorGasolina * (capacidadeTanque * (1 / 5));
                    break;

                case "Cheio":
                    total = 0;
                    break;
            }

            return total;
        }

    }
}
