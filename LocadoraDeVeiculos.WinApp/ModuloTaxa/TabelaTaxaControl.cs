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
            grid.ConfigurarColunaId();

            this.servicoTaxa = servico;
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
