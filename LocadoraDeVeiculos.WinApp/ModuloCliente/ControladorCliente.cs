using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private TabelaClientesControl tabelaClientes;
        private ServicoCliente servicoCliente;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }
        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm("Insercao");
            tela.Cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            var id = tabelaClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


                var clienteSelecionado = resultadoSelecao.Value;

                TelaCadastroClienteForm tela = new TelaCadastroClienteForm("Edicao");

                tela.Cliente = clienteSelecionado;

                tela.GravarRegistro = servicoCliente.Editar;

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                    CarregarClientes();

        }

        public override void Excluir()
        {
            var id = tabelaClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o clientes?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(clienteSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarClientes()
        {
            var resultadoSelecao = servicoCliente.SelecionarTodos();
           

            if (resultadoSelecao.IsSuccess) {

                List<Cliente> clientes = resultadoSelecao.Value;

                tabelaClientes.AtualizarRegistros(clientes);
            }
            else 
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Carregar Clientes"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public override UserControl ObtemListagem()
        {
            if(tabelaClientes == null)
                tabelaClientes = new TabelaClientesControl(servicoCliente);

            CarregarClientes();

            return tabelaClientes;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }
    }
}
