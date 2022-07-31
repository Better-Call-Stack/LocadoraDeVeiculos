﻿using FluentResults;
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
        TabelaDevolucaoControl tabelaDevolucao;
        TabelaLocacoesControl tabelaLocacoes;
        ServicoLocacao servicoLocacao;
        ServicoTaxa servicoTaxa;
        private List<Taxa> taxas = new List<Taxa>();

        public TelaCadastroDevolucaoForm(ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
            //this.taxas = new List<Taxa>();
            CarregarVolumeTanque();
            CarregarTaxas();
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

                if(devolucao.Locacao != null)
                {
                    txtCliente.Text = devolucao.Locacao.Cliente.Nome;
                    txtVeiculo.Text = devolucao.Locacao.Veiculo.Modelo;
                    comboBoxVolumeTanque.SelectedItem = devolucao.VolumeTanque;
                    DataDevolucao.Value = devolucao.DataDevolucao;
                    Quilometragem.Text = devolucao.Quilometragem.ToString();
                    ValorGasolina.Text = devolucao.ValorGasolina.ToString();

                    int posicao = 0;
                    foreach (var taxa in devolucao.Locacao.Taxas)
                    {
                        for (int j = 0; j < cklistTaxas.Items.Count; j++)
                        {
                            if (taxa == cklistTaxas.Items[j])
                                cklistTaxas.SetItemChecked(posicao, true);

                            posicao++;
                        }
                        posicao = 0;
                    }
                }
            }
        }

        private void CarregarVolumeTanque()
        {
            var volumeTanque = Enum.GetValues(typeof(VolumeTanque));

            foreach (var volume in volumeTanque)
            {
                comboBoxVolumeTanque.Items.Add(volume);
            }
        }

        private void CarregarTaxas()
        {
            var resultadoSelecao = servicoTaxa.SelecionarTodos();

            if (resultadoSelecao.IsSuccess)
            {
                List<Taxa> taxas = servicoTaxa.SelecionarTodos().Value;

                foreach (var taxa in taxas)
                {
                    cklistTaxas.Items.Add(taxa);
                }
            }
        }

        private void ConfigurarListagemLocacao()
        {
            tabelaDevolucao = new TabelaDevolucaoControl();
            tabelaDevolucao.AtualizarRegistrosAtivos(servicoLocacao.SelecionarTodos().Value);

            Controls.Clear();

            tabelaDevolucao.Dock = DockStyle.Fill;

            Controls.Add(tabelaDevolucao);
        }
    }
}
