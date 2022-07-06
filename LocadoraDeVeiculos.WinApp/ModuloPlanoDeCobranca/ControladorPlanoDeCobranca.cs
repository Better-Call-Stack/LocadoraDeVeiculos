﻿using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
        private RepositorioPlanoDeCobrancaEmBancoDados repositorioGrupoVeiculos;
        private TabelaPlanoDeCobrancaControl tabelaGrupoVeiculos;
        private readonly ServicoPlanoDeCobranca servicoGrupoVeiculos;

        public ControladorPlanoDeCobranca(RepositorioPlanoDeCobrancaEmBancoDados repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
        }

        public override void Inserir()
        {
            TelaPlanoDeCobrancaForm tela = new TelaPlanoDeCobrancaForm();
            tela.PlanoDeCobranca = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlanoDeCobrancas.Inserir;

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

            TelaPlanoDeCobrancaForm tela = new TelaPlanoDeCobrancaForm();

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
                repositorioPlanoDeCobranca.Excluir(planoDeCobrancaSelecionado);
                CarregarPlanoDeCobranca();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoDeCobranca == null)
                tabelaPlanoDeCobranca = new TabelaPlanoDeCobrancaControl();

            CarregarGrupoVeiculos();

            return tabelaPlanoDeCobranca;
        }

        public override ConfiguracaoToolboxPlanoDeCobranca ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoDeCobranca();
        }

        private void CarregarPlanoDeCobranca()
        {
            List<PlanoDeCobranca> planoDeCobranca = repositorioPlanoDeCobranca.SelecionarTodos();

            tabelaPlanoDeCobranca.AtualizarRegistros(planoDeCobranca);
        }

        private PlanoDeCobranca ObtemPlanoDeCobrancaSelecionado()
        {
            var id = tabelaPlanoDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            return repositorioPlanoDeCobranca.SelecionarPorId(id);
        }
    }
}
