using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private ServicoLocacao servicoLocacao;
        private ServicoCliente servicoCliente;
        private ServicoVeiculo servicoVeiculo;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        private ServicoCondutor servicoCondutor;
        private ServicoPlanoDeCobranca servicoPlanoCobranca;
        private ServicoTaxa servicoTaxa;


        private TabelaLocacoesControl tabelaLocacao;

        public ControladorLocacao(ServicoLocacao servicoLocacao, ServicoCliente servicoCliente,
            ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoCondutor servicoCondutor,
            ServicoPlanoDeCobranca servicoPlanoCobranca, ServicoTaxa servicoTaxa)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCliente = servicoCliente;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoCondutor = servicoCondutor;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(servicoCliente, servicoVeiculo, servicoGrupoVeiculos,
                servicoCondutor, servicoPlanoCobranca, servicoTaxa);
            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarLocacoes();
            }
        }

        public override void Editar()
        {
            var id = tabelaLocacao.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                "Edição de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var locacaoSelecionado = resultadoSelecao.Value;

            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(servicoCliente, servicoVeiculo,
                servicoGrupoVeiculos, servicoCondutor, servicoPlanoCobranca, servicoTaxa);

            tela.Locacao = locacaoSelecionado;

            tela.GravarRegistro = servicoLocacao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacoes();
        }
        
        public override void Excluir()
        {
            var id = tabelaLocacao.ObtemIdLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locaçãoo primeiro",
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locação",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxLocacao();
        }
        
        public override UserControl ObtemListagem()
        {
            tabelaLocacao = new TabelaLocacoesControl();

            CarregarLocacoes();

            return tabelaLocacao;
        }
       
        private void CarregarLocacoes()
        {
            var resultadoSelecao = servicoLocacao.SelecionarTodos();


            if (resultadoSelecao.IsSuccess)
            {

                List<Locacao> locacoes = resultadoSelecao.Value;

                tabelaLocacao.AtualizarRegistros(locacoes);
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Carregar locacoes"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
