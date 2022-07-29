using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {

        ServicoTaxa servicoTaxa;

        public TabelaTaxaControl(ServicoTaxa servico)
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
            this.servicoTaxa = servico;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo", HeaderText = "Tipo"},
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();

            foreach (Taxa t in taxas)
            {
                grid.Rows.Add(t.Id, t.Nome, t.Valor, t.Tipo);
            }

        }

        public Guid ObtemIdTaxaSelecionada()
        {
            return grid.SelecionarId<Guid>();
        }
    }
}
