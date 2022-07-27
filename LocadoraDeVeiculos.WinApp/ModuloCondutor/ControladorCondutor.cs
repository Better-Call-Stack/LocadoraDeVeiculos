using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private ServicoCondutor servicoCondutor;
        private ServicoCliente servicoCliente;
        private TabelaCondutoresControl tabelaCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.servicoCliente = servicoCliente;
        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var condutorSelecionado = resultadoSelecao.Value;

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(servicoCliente.SelecionarTodos().Value, "Edicao");

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarCondutores();
        }

        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de Condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(condutorSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Inserir()
        {
            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(servicoCliente.SelecionarTodos().Value, "Insercao");
            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        private void CarregarCondutores()
        {
            var resultadoSelecao = servicoCondutor.SelecionarTodos();


            if (resultadoSelecao.IsSuccess)
            {

                List<Condutor> condutores = resultadoSelecao.Value;

                tabelaCondutor.AtualizarRegistros(condutores);
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Carregar Condutores"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

     
        
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            tabelaCondutor = new TabelaCondutoresControl(servicoCondutor, servicoCliente);

            CarregarCondutores();

            return tabelaCondutor;
        }
    }
}
