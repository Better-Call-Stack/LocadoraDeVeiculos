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
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;


        public ControladorPlanoDeCobranca(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaPlanoDeCobrancaForm tela = new TelaPlanoDeCobrancaForm(servicoGrupoVeiculos.SelecionarTodos().Value);
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
            PlanoDeCobranca planoDeCobrancaSelecionado = ObtemPlanoDeCobrancaSelecionado();

            if (planoDeCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Edição do plano de cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaPlanoDeCobrancaForm tela = new TelaPlanoDeCobrancaForm(servicoGrupoVeiculos.SelecionarTodos().Value);

            tela.PlanoDeCobranca = planoDeCobrancaSelecionado.Clonar();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoDeCobranca();
            }
        }

        public override void Excluir()
        {
            PlanoDeCobranca planoDeCobrancaSelecionado = ObtemPlanoDeCobrancaSelecionado();

            if (planoDeCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veiculos primeiro",
                "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
                "Exclusão do plano de cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servicoPlanoDeCobranca.Excluir(planoDeCobrancaSelecionado);
                CarregarPlanoDeCobranca();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoDeCobranca == null)
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
            List<PlanoDeCobranca> planoDeCobranca = servicoPlanoDeCobranca.SelecionarTodos().Value;

            tabelaPlanoDeCobranca.AtualizarRegistros(planoDeCobranca);
        }

        private PlanoDeCobranca ObtemPlanoDeCobrancaSelecionado()
        {
            var id = tabelaPlanoDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            return servicoPlanoDeCobranca.SelecionarPorId(id).Value;
        }
    }
}
