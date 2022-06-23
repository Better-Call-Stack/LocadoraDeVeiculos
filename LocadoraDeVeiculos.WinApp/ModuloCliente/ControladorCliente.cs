using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly RepositorioCliente repositorioCliente;
        private TabelaClientesControl tabelaClientes;

        public ControladorCliente(RepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override void Editar()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado.Clonar();

            tela.GravarRegistro = repositorioCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a contato?",
                "Exclusão de Contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(clienteSelecionado);
                CarregarClientes();
            }
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = repositorioCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(clientes);

            //TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {contatos.Count} contato(s)");
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = tabelaClientes.ObtemIdClienteSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }

        public override UserControl ObtemListagem()
        {
            tabelaClientes = new TabelaClientesControl();

            CarregarClientes();

            return tabelaClientes;
        }
    }
}
