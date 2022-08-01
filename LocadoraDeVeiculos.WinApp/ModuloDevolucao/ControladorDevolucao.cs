using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucao : ControladorBase
    {
        private TabelaDevolucaoControl tabelaDevolucao;
        private ServicoDevolucao servicoDevolucao;
        private ServicoLocacao servicoLocacao;
        private ServicoTaxa servicoTaxa;

        public ControladorDevolucao(ServicoDevolucao servicoDevolucao, ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa)
        {
            this.servicoDevolucao = servicoDevolucao;
            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            var id = tabelaDevolucao.ObtemIdSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Inserindo Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Inseção Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultado.Value;

            var tela = new TelaCadastroDevolucaoForm(servicoLocacao, servicoTaxa, devolucaoSelecionada);
            tela.Devolucao = new Devolucao();

            tela.GravarRegistro = servicoDevolucao.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarDevolucao();
            }

        }

        public override void Editar()
        {
            var id = tabelaDevolucao.ObtemIdSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma devolução",
                    "Edição da Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoDevolucao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição da Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultado.Value;

            var tela = new TelaCadastroDevolucaoForm(servicoLocacao, servicoTaxa);

            tela.Devolucao = devolucaoSelecionada;

            tela.GravarRegistro = servicoDevolucao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarDevolucao();
        }

        public override void Excluir()
        {
            var id = tabelaDevolucao.ObtemIdSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma devolução primeiro",
                    "Exclusão da Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoDevolucao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão da Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Devolução?", "Exclusão da Devolução",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoDevolucao.Excluir(devolucaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarDevolucao();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão da Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            tabelaDevolucao = new TabelaDevolucaoControl();

            CarregarDevolucao();

            return tabelaDevolucao;
        }

        private void CarregarDevolucao()
        {
            var resultadoSelecaoAtivos = servicoLocacao.SelecionarTodos();
            var resultadoSelecaoInativos = servicoDevolucao.SelecionarTodos();

            if (resultadoSelecaoAtivos.IsSuccess)
            {
                List<Locacao> locacao = resultadoSelecaoAtivos.Value;
                tabelaDevolucao.AtualizarRegistrosAtivos(locacao);
            }
            if (resultadoSelecaoInativos.IsSuccess)
            {
                List<Devolucao> devolucao = resultadoSelecaoInativos.Value;
                tabelaDevolucao.AtualizarRegistrosInativos(devolucao);
            }
            else
            {
                MessageBox.Show(resultadoSelecaoInativos.Errors[0].Message, "Carregar devolução"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
