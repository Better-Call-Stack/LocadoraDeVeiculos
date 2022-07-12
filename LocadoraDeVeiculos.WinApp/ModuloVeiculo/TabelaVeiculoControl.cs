using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        RepositorioVeiculo repositorio;
        RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        public TabelaVeiculoControl(RepositorioVeiculo repositorio, RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            InitializeComponent();
            gridVeiculo.ConfigurarGridZebrado();
            gridVeiculo.ConfigurarGridSomenteLeitura();
            gridVeiculo.ConfigurarColunaId();
            this.repositorio = repositorio;
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }
        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            gridVeiculo.Rows.Clear();

            foreach (Veiculo v in veiculos)
            {
                gridVeiculo.Rows.Add(v.Id, v.Modelo, v.Fabricante, v.Placa, v.KmPercorrido, v.StatusVeiculo,
                    v.TipoCombustivel, v.CapacidadeTanque);
            }
        }

        public int ObtemIdVeiculoSelecionado()
        {
            return gridVeiculo.SelecionarId<int>();
        }

        private void gridVeiculo_DoubleClick(object sender, EventArgs e)
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo("Visualizacao", repositorioGrupoVeiculos.SelecionarTodos());
            int id = ObtemIdVeiculoSelecionado();
            Veiculo v = repositorio.SelecionarPorId(id);

            tela.Veiculo = v;
            tela.ShowDialog();
        }
    }
}
