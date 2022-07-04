using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System.Collections.Generic;
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
            grid.ConfigurarColunaId();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},


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
                grid.Rows.Add(veiculo.Id, veiculo.Nome);
            }
        }
    }
}
