using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
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
        public TabelaVeiculoControl(RepositorioVeiculo repositorio)
        {
            InitializeComponent();
            gridVeiculo.ConfigurarGridZebrado();
            gridVeiculo.ConfigurarGridSomenteLeitura();
            gridVeiculo.ConfigurarColunaId();
            this.repositorio = repositorio;
        }
        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            gridVeiculo.Rows.Clear();

            foreach (Veiculo v in veiculos)
            {
                gridVeiculo.Rows.Add(v.Id, v.Grupo, v.Placa, v.Modelo, v.Fabricante, v.Cor,
                    v.TipoCombustivel, v.CapacidadeTanque);
            }
        }

        public int ObtemIdVeiculoSelecionado()
        {
            return gridVeiculo.SelecionarId<int>();
        }
    }
}
