using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
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

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TabelaClientesControl : UserControl
    {
        RepositorioCliente repositorio;


        public TabelaClientesControl(RepositorioCliente repositorio)
        {
            InitializeComponent();
            gridPessoaFisica.ConfigurarGridZebrado();
            gridPessoaFisica.ConfigurarGridSomenteLeitura();
            gridPessoaJuridica.ConfigurarGridZebrado();
            gridPessoaJuridica.ConfigurarGridSomenteLeitura();
            gridPessoaFisica.ConfigurarColunaId();
            gridPessoaJuridica.ConfigurarColunaId();

            this.repositorio = repositorio;
        }

        internal void AtualizarRegistros(List<Cliente> clientes)
        {
            gridPessoaFisica.Rows.Clear();
            gridPessoaJuridica.Rows.Clear();

            List<Cliente> pessoasFisicas = SelecionarPessoaFisica(clientes);
            List<Cliente> pessoasJuridicas = SelecionarPessoaJuridica(clientes);

            foreach (var c in pessoasFisicas)
            {
                gridPessoaFisica.Rows.Add(c.Id, c.Nome, c.CPF, c.Telefone, c.Email);
            }

            foreach (var c in pessoasJuridicas)
            {
                gridPessoaJuridica.Rows.Add(c.Id, c.Nome, c.CNPJ, c.Telefone, c.Email);
            }
        }

        private List<Cliente> SelecionarPessoaFisica(List<Cliente> clientes)
        {
            List<Cliente> pessoasFisicas = new List<Cliente>();

            foreach (var c in clientes)
            {
                if (c.TipoPessoa == TipoPessoa.Fisica)
                    pessoasFisicas.Add(c);
            }

            return pessoasFisicas;
        }

        private List<Cliente> SelecionarPessoaJuridica(List<Cliente> clientes)
        {
            List<Cliente> pessoasJuridicas = new List<Cliente>();

            foreach (var c in clientes)
            {
                if (c.TipoPessoa == TipoPessoa.Juridica)
                    pessoasJuridicas.Add(c);
            }

            return pessoasJuridicas;
        }

        public int ObtemIdClienteSelecionado()
        {
            if (tabControl.SelectedTab.Name == "tabPessoaFisica")
            {
                return gridPessoaFisica.SelecionarId<int>();
            }
            else
                return gridPessoaJuridica.SelecionarId<int>();

        }

        private void gridPessoaFisica_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridDoubleClickGenerico();
        }

        private void GridDoubleClickGenerico()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm("Visualizacao");
            int id = ObtemIdClienteSelecionado();
            Cliente c = repositorio.SelecionarPorId(id);

            tela.Cliente = c;
            tela.ShowDialog();
        }

        private void gridPessoaJuridica_DoubleClick(object sender, EventArgs e)
        {
            GridDoubleClickGenerico();
        }

    }
}
