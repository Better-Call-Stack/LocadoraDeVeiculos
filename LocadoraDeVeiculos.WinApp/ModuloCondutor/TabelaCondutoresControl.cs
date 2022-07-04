using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
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

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TabelaCondutoresControl : UserControl
    {
        RepositorioCondutor repositorioCondutor;
        public TabelaCondutoresControl(RepositorioCondutor repositorioCondutor)
        {
            InitializeComponent();

            gridCondutores.ConfigurarGridZebrado();
            gridCondutores.ConfigurarGridSomenteLeitura();
            gridCondutores.ConfigurarGridZebrado();

            this.repositorioCondutor = repositorioCondutor;
        }

        internal void AtualizarRegistros(List<Condutor> condutores)
        {
            gridCondutores.Rows.Clear();

            foreach (var c in condutores)
            {
                gridCondutores.Rows.Add(c.Id, c.Nome, c.CPF, c.CNH, c.ValidadeCNH, c.Cliente);
            }
        }

        public int ObtemIdCondutorSelecionado()
        {
                return gridCondutores.SelecionarId<int>();
        }

        private void gridCondutores_DoubleClick(object sender, EventArgs e)
        {
            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm("Visualizacao");
            int id = ObtemIdCondutorSelecionado();
            Condutor c = repositorioCondutor.SelecionarPorId(id);

            tela.Condutor = c;
            tela.ShowDialog();
        }
    }
}
