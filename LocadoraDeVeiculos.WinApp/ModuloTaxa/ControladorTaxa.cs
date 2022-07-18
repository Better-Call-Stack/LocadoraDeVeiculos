using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {

        private ServicoTaxa servico;
        private TabelaTaxaControl tabelaTaxas;

        public ControladorTaxa(ServicoTaxa servico)
        {
            this.servico = servico;
        }
        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = servico.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }
        
        public override void Editar()
        {
            var id = tabelaTaxas.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servico.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var TaxaSelecionado = resultadoSelecao.Value;

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();

            tela.Taxa = TaxaSelecionado.Clonar();

            tela.GravarRegistro = servico.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            var id = tabelaTaxas.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servico.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servico.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            tabelaTaxas = new TabelaTaxaControl(servico);

            CarregarTaxas();

            return tabelaTaxas;
        }

        private void CarregarTaxas()
        {
            var resultadoSelecao = servico.SelecionarTodos();


            if (resultadoSelecao.IsSuccess)
            {

                List<Taxa> taxas = resultadoSelecao.Value;

                tabelaTaxas.AtualizarRegistros(taxas);
            }
            else
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message, "Carregar Taxas"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
