using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
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

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos
{
    public partial class TabelaGrupoVeiculosControl : UserControl
    {
        public TabelaGrupoVeiculosControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPlanoDiario", HeaderText = "Plano Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiariaKmControlado", HeaderText = "Diária Km Controlado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiarioKmLivre", HeaderText = "Diária Km Livre"},
            };

            return colunas;
        }

        public int ObtemIdGrupoVeiculoSelecionado()
        {
            return grid.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<GrupoDeVeiculos> veiculos)
        {
            grid.Rows.Clear();

            foreach (GrupoDeVeiculos veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.Id, veiculo.ValorPlanoDiario, veiculo.ValorDiariaKmControlado, veiculo.ValorDiarioKmLivre);
            }
        }
    }
}
