using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TelaPlanoDeCobrancaForm : Form
    {

        public TelaPlanoDeCobrancaForm(List<GrupoDeVeiculos> grupoDeVeiculos)
        {
            InitializeComponent();
            CarregarGrupoDeVeiculos(grupoDeVeiculos);
        }

        private void CarregarGrupoDeVeiculos(List<GrupoDeVeiculos> grupoDeVeiculos)
        {
            comboBoxGrupoVeiculos.Items.Clear();

            foreach (var item in grupoDeVeiculos)
            {
                comboBoxGrupoVeiculos.Items.Add(item);
            }
        }

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get; set; }

        private PlanoDeCobranca planoDeCobranca;

        public PlanoDeCobranca PlanoDeCobranca
        {
            get { return planoDeCobranca; }
            set
            {
                planoDeCobranca = value;


                txtValorKmRodado_PlanoDiario.Text = planoDeCobranca.txtValorKmRodado_PlanoDiario.ToString();
                txtValorPorDia_PlanoDiario.Text = planoDeCobranca.txtValorPorDia_PlanoDiario.ToString();
                txtValorKmRodado_PlanoKmControlado.Text = planoDeCobranca.txtValorKmRodado_PlanoKmControlado.ToString();
                txtKmLivreIncluso_PlanoKmControlado.Text = planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado.ToString();
                txtValorPorDia_PlanoKmControlado.Text = planoDeCobranca.txtValorPorDia_PlanoKmControlado.ToString();
                txtValorPorDia_PlanoKmLivre.Text = planoDeCobranca.txtValorPorDia_PlanoKmLivre.ToString();
                comboBoxGrupoVeiculos.SelectedItem = planoDeCobranca.GrupoDeVeiculos;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            planoDeCobranca.txtValorKmRodado_PlanoDiario = Convert.ToDecimal(txtValorKmRodado_PlanoDiario.Text);
            planoDeCobranca.txtValorPorDia_PlanoDiario = Convert.ToDecimal(txtValorPorDia_PlanoDiario.Text);
            planoDeCobranca.txtValorKmRodado_PlanoKmControlado = Convert.ToDecimal(txtValorKmRodado_PlanoKmControlado.Text);
            planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado = Convert.ToDecimal(txtKmLivreIncluso_PlanoKmControlado.Text);
            planoDeCobranca.txtValorPorDia_PlanoKmControlado = Convert.ToDecimal(txtValorPorDia_PlanoKmControlado.Text);
            planoDeCobranca.txtValorPorDia_PlanoKmLivre = Convert.ToDecimal(txtValorPorDia_PlanoKmLivre.Text);
            planoDeCobranca.GrupoDeVeiculos = (GrupoDeVeiculos)comboBoxGrupoVeiculos.SelectedItem;

            var resultadoValidacao = GravarRegistro(planoDeCobranca);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Erro");

                DialogResult = DialogResult.None;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
