using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
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

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TabelaPlanoDeCobrancaControl : UserControl
    {
        public TabelaPlanoDeCobrancaControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarColunaId();
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "comboBoxGrupoVeiculos", HeaderText = "Grupo de Veículos"},

            };

            return colunas;
        }

        public int ObtemIdPlanoDeCobrancaSelecionado()
        {
            return grid.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> cobrancas)
        {
            grid.Rows.Clear();

            foreach (PlanoDeCobranca cobranca in cobrancas)
            {
                grid.Rows.Add(cobranca.Id, cobranca.GrupoDeVeiculos.Nome);
            }
        }
    }
}
