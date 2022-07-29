using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
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
        ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        ServicoGrupoVeiculos servicoGrupoVeiculos;

        public TabelaPlanoDeCobrancaControl(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "comboBoxGrupoVeiculos", HeaderText = "Grupo de Veículos"},
            };

            return colunas;
        }

        public Guid ObtemIdPlanoDeCobrancaSelecionado()
        {
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> cobrancas)
        {
            grid.Rows.Clear();

            foreach (PlanoDeCobranca cobranca in cobrancas)
            {
                grid.Rows.Add(cobranca.Id, cobranca.GrupoDeVeiculos.Nome);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            TelaPlanoDeCobrancaForm tela = new TelaPlanoDeCobrancaForm(servicoGrupoVeiculos.SelecionarTodos().Value,"Visualizacao");
            Guid id = ObtemIdPlanoDeCobrancaSelecionado();
            PlanoDeCobranca p = servicoPlanoDeCobranca.SelecionarPorId(id).Value;

            tela.PlanoDeCobranca = p;
            tela.ShowDialog();
        }
    }
}
