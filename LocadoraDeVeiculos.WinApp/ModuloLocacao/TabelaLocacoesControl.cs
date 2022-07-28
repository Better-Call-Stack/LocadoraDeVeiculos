using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TabelaLocacoesControl : UserControl
    {
        public TabelaLocacoesControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},
              
                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},
                
                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},
                
                new DataGridViewTextBoxColumn { DataPropertyName = "Plano", HeaderText = "Plano"},
               
                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"},
               
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status"}

            };

            return colunas;
        }

        public Guid ObtemIdLocacaoSelecionada()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (Locacao locacao in locacoes)
            {
                grid.Rows.Add(locacao.Cliente.Nome, locacao.Condutor.Nome, locacao.Veiculo.Modelo, locacao.PlanoSelecionado,
                    locacao.Valor, locacao.StatusLocacao);
            }
        }
    }
}
