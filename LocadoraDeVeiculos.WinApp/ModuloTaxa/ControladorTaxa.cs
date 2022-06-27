using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {

        RepositorioTaxa repositorio;
        private TabelaTaxaControl tabelaTaxas;

        public ControladorTaxa(RepositorioTaxa repositorio)
        {
            this.repositorio = repositorio; 
        }
        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            TelaCadastroTaxaForm tela = new TelaCadastroTaxaForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            throw new NotImplementedException();
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
    }
}
