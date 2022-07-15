using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TabelaClientesControl : UserControl
    {
        ServicoCliente servico;


        public TabelaClientesControl(ServicoCliente servico)
        {
            InitializeComponent();
            gridPessoaFisica.ConfigurarGridZebrado();
            gridPessoaFisica.ConfigurarGridSomenteLeitura();
            gridPessoaJuridica.ConfigurarGridZebrado();
            gridPessoaJuridica.ConfigurarGridSomenteLeitura();
            gridPessoaFisica.ConfigurarColunaId();
            gridPessoaJuridica.ConfigurarColunaId();
            this.servico = servico;
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

        public Guid ObtemIdClienteSelecionado()
        {
            if (tabControl.SelectedTab.Name == "tabPessoaFisica")
            {
                return gridPessoaFisica.SelecionarId<Guid>();
            }
            else
                return gridPessoaJuridica.SelecionarId<Guid>();

        }

        private void gridPessoaFisica_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridDoubleClickGenerico();
        }

        private void GridDoubleClickGenerico()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm("Visualizacao");
            
            Guid id = ObtemIdClienteSelecionado();
          
            var resultado = servico.SelecionarPorId(id);
            
            Cliente c = resultado.Value;

            tela.Cliente = c;
            tela.ShowDialog();
        }

        private void gridPessoaJuridica_DoubleClick(object sender, EventArgs e)
        {
            GridDoubleClickGenerico();
        }

    }
}
