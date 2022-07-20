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
            gridVeiculo.ConfigurarGridZebrado();
            gridVeiculo.ConfigurarGridSomenteLeitura();
            gridVeiculo.ConfigurarColunaId();
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }
        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            gridVeiculo.Rows.Clear();

            foreach (Veiculo v in veiculos)
            {
                gridVeiculo.Rows.Add(v.Id, v.Placa, v.Modelo, v.Fabricante, v.Grupo.Nome, v.StatusVeiculo, v.TipoCombustivel);
            }
        }

        public Guid ObtemIdVeiculoSelecionado()
        {
            return gridVeiculo.SelecionarId<Guid>();
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
