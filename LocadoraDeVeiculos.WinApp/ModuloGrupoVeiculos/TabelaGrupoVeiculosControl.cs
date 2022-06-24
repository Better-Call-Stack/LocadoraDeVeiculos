using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
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

        }

        internal void AtualizarRegistro(List<GrupoDeVeiculos> grupoVeiculos)
        {
            gridGrupoVeiculos.Rows.Clear();

            foreach (GrupoDeVeiculos grupoDeVeiculo in grupoVeiculos)
            {
                gridGrupoVeiculos.Rows.Add(grupoDeVeiculo.Id, grupoDeVeiculo.Nome, grupoDeVeiculo.ValorPlanoDiario, 
                    grupoDeVeiculo.ValorDiariaKmControlado, grupoDeVeiculo.ValorDiarioKmLivre);
            }
        }

        internal GrupoDeVeiculos SelecionarGrupoVeiculos()
        {
            return new GrupoDeVeiculos();
        }
    }
}
