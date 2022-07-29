using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        ServicoVeiculo servicoVeiculo;
        ServicoGrupoVeiculos servicoGrupoVeiculos;
        public TabelaVeiculoControl(ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Fabricante", HeaderText = "Fabricante"},

                new DataGridViewTextBoxColumn { DataPropertyName = "cmbGrupoVeiculo", HeaderText = "Grupo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "StatusVeiculo", HeaderText = "Status"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Combustível"},
            };

            return colunas;
        }

        public Guid ObtemIdVeiculoSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (Veiculo v in veiculos)
            {
                grid.Rows.Add(v.Id, v.Placa, v.Modelo, v.Fabricante, v.Grupo.Nome, v.StatusVeiculo, v.TipoCombustivel);
            }
        }

        private void gridVeiculo_DoubleClick(object sender, EventArgs e)
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo("Visualizacao", servicoGrupoVeiculos.SelecionarTodos().Value);
            Guid id = ObtemIdVeiculoSelecionado();
            Veiculo v = servicoVeiculo.SelecionarPorId(id).Value;

            tela.Veiculo = v;
            tela.ShowDialog();
        }
    }
}
