using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private TabelaPlanoDeCobrancaControl tabelaPlanoDeCobranca;
        private ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorPlanoDeCobranca(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaPlanoDeCobrancaForm(servicoGrupoVeiculos.SelecionarTodos().Value, "Inserção");
            tela.PlanoDeCobranca = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoDeCobranca();
            }
        }

        public override void Editar()
        {
            var id = tabelaPlanoDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                    "Edição do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição do Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoDeCobrancaSelecionado = resultado.Value;

            var tela = new TelaPlanoDeCobrancaForm(servicoGrupoVeiculos.SelecionarTodos().Value, "Edção");

            tela.PlanoDeCobranca = planoDeCobrancaSelecionado; //Clonar();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanoDeCobranca();
        }

        public override void Excluir()
        {
            var id = tabelaPlanoDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                    "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão do Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoDeCobrancaSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Plano de Cobrança?", "Exclusão do Plano de Cobrança",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoDeCobranca.Excluir(planoDeCobrancaSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanoDeCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão do Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            //if (tabelaPlanoDeCobranca == null)
                tabelaPlanoDeCobranca = new TabelaPlanoDeCobrancaControl(servicoPlanoDeCobranca, servicoGrupoVeiculos);

            CarregarPlanoDeCobranca();

            return tabelaPlanoDeCobranca;
        }

        public override ConfiguracaoToolboxPlanoDeCobranca ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoDeCobranca();
        }

        private void CarregarPlanoDeCobranca()
        {
            var resultadoSelecao = servicoPlanoDeCobranca.SelecionarTodos();


            if (resultadoSelecao.IsSuccess)
            {

                List<PlanoDeCobranca> planoDeCobranca = resultadoSelecao.Value;

                tabelaPlanoDeCobranca.AtualizarRegistros(planoDeCobranca);
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Carregar Condutores"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /* private PlanoDeCobranca ObtemPlanoDeCobrancaSelecionado()
        {
            var id = tabelaPlanoDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            return s.SelecionarPorId(id);
        }*/
    }
}
