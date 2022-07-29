using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
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
        ServicoCondutor servicoCondutor;
        ServicoCliente servicoCliente;
        public TabelaCondutoresControl(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            InitializeComponent();

            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValidadeCNH", HeaderText = "Validade CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "cbxCliente", HeaderText = "Cliente"},
            };

            return colunas;
        }
        public Guid ObtemIdCondutorSelecionado()
        {
                return grid.SelecionarId<Guid>();
        }

        internal void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();

            foreach (var c in condutores)
            {
                grid.Rows.Add(c.Id, c.Nome, c.CPF, c.CNH, c.ValidadeCNH.ToShortDateString(), c.Cliente.Nome);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(servicoCliente.SelecionarTodos().Value, "Visualizacao");
            Guid id = ObtemIdCondutorSelecionado();
            Condutor c = servicoCondutor.SelecionarPorId(id).Value;

            tela.Condutor = c;
            tela.ShowDialog();
        }
    }
}
