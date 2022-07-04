using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {

        private readonly RepositorioTaxa repositorio;
        private ServicoTaxa servico;
        private TabelaTaxaControl tabelaTaxas;

        public ControladorTaxa(RepositorioTaxa repositorio, ServicoTaxa servico)
        {
            this.repositorio = repositorio;
            this.servico = servico;
        }
        public override void Editar()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();

            tela.Taxa = taxaSelecionada.Clonar();

            tela.GravarRegistro = servico.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            Taxa taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorio.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
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

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            tabelaTaxas = new TabelaTaxaControl(repositorio);

            CarregarTaxas();

            return tabelaTaxas;
        }

        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorio.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(taxas);

        }


        private Taxa ObtemTaxaSelecionada()
        {
            var id = tabelaTaxas.ObtemIdTaxaSelecionada();

            return repositorio.SelecionarPorId(id);
        }
    }
}
