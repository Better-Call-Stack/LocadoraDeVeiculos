using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class BotaoSelecionarForm : Form
    {
        private ServicoCliente servicoCliente;
        private ServicoVeiculo servicoVeiculo;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        private TabelaClientesControl tabelaClientes;
        private TabelaVeiculoControl tabelaVeiculos;

        public Cliente cliente;
        public Veiculo veiculo;
       


        public BotaoSelecionarForm(ServicoCliente servicoCliente)
        {
            InitializeComponent();

            this.servicoCliente = servicoCliente;
            this.Text = "Selecionar Cliente";

             ConfigurarListagemCliente();

        }

        public BotaoSelecionarForm(ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculos servicoGrupoVeiculos, 
            GrupoDeVeiculos grupo)
        {
            InitializeComponent();

            this.Text = "Selecionar Veiculo";

            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoVeiculo = servicoVeiculo;

            ConfigurarListagemVeiculo(grupo);
        }

        private void ConfigurarListagemCliente()
        {
            tabelaClientes = new TabelaClientesControl(servicoCliente);
            tabelaClientes.AtualizarRegistros(servicoCliente.SelecionarTodos().Value);

            painel.Controls.Clear();

            tabelaClientes.Dock = DockStyle.Fill;

            painel.Controls.Add(tabelaClientes);
        }

        private void ConfigurarListagemVeiculo(GrupoDeVeiculos grupo)
        {
            tabelaVeiculos = new TabelaVeiculoControl(servicoVeiculo, servicoGrupoVeiculos);

            List<Veiculo> veiculos = servicoVeiculo.SelecionarTodos().Value;

            List<Veiculo> veiculosFiltrado = veiculos.Where(x => x.Grupo == grupo).ToList();
            

            tabelaVeiculos.AtualizarRegistros(veiculosFiltrado);

            painel.Controls.Clear();

            tabelaVeiculos.Dock = DockStyle.Fill;

            painel.Controls.Add(tabelaVeiculos);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
          if(painel.Controls[0] == tabelaVeiculos)
            {
                var id = tabelaVeiculos.ObtemIdVeiculoSelecionado();

                if (id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um veiculo primeiro",
                    "Selecao de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

                if (resultadoSelecao.IsFailed)
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Selecao de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if(resultadoSelecao.Value.StatusVeiculo != StatusVeiculoEnum.Disponível)
                {
                    MessageBox.Show("Veiculo não está disponível para locação",
                    "Selecao de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                veiculo = resultadoSelecao.Value;
            }

            if (painel.Controls[0] == tabelaClientes)
            {
                var id = tabelaClientes.ObtemIdClienteSelecionado();

                if (id == Guid.Empty)
                {
                    MessageBox.Show("Selecione um cliente primeiro",
                    "Selecao de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var resultadoSelecao = servicoCliente.SelecionarPorId(id);

                if (resultadoSelecao.IsFailed)
                {
                    MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Selecao de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                cliente = resultadoSelecao.Value;
            }
        }
    }
}
