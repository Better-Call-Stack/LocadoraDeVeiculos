using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Infra.ModuloTaxa;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TabelaTaxaControl : UserControl
    {

        RepositorioTaxa repositorio;

        public TabelaTaxaControl(RepositorioTaxa repositorio)
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarColunaId();

            this.repositorio = repositorio;
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
