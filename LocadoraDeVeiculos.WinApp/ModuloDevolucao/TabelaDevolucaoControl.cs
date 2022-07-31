using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
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
    public partial class TabelaDevolucaoControl : UserControl
    {


        public TabelaDevolucaoControl()
        {
            InitializeComponent();
            gridAtivos.ConfigurarGridZebrado();
            gridAtivos.ConfigurarGridSomenteLeitura();
            gridInativo.ConfigurarGridZebrado();
            gridInativo.ConfigurarGridSomenteLeitura();
            gridAtivos.Columns.AddRange(ObterColunasAtivos());
            gridInativo.Columns.AddRange(ObterColunasInativo());
        }

        public DataGridViewColumn[] ObterColunasAtivos()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Plano", HeaderText = "Plano"},
            };

            return colunas;
        }
        public DataGridViewColumn[] ObterColunasInativo()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Devolução"},
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            if (tabelaControl.SelectedTab.Name == "tabAtivos")
            {
                return gridAtivos.SelecionarId<Guid>();
            }
            else
            {
                return gridInativo.SelecionarId<Guid>();
            }
        }

        public void AtualizarRegistrosAtivos(List<Locacao> locacoes)
        {
            gridAtivos.Rows.Clear();

            foreach (var locacao in locacoes)
            {
                gridAtivos.Rows.Add(locacao.Id, locacao.Cliente.Nome, locacao.Condutor.Nome, 
                    locacao.Veiculo.Modelo, locacao.PlanoSelecionado);
            }
        }

        public void AtualizarRegistrosInativos(List<Devolucao> devolucoes)
        {
            gridInativo.Rows.Clear();

            foreach (Devolucao devolucao in devolucoes)
            {
                gridInativo.Rows.Add(devolucao.Id, devolucao.Locacao.Cliente.Nome,
                    devolucao.Locacao.Condutor.Nome, devolucao.Locacao.Veiculo.Modelo, devolucao.DataDevolucao);
            }
        }
    }
}
