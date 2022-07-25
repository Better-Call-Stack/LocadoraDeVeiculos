using FluentResults;
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

        public TelaPlanoDeCobrancaForm(List<GrupoDeVeiculos> grupoDeVeiculos, string modoTela)
        {
            InitializeComponent();
            CarregarGrupoDeVeiculos(grupoDeVeiculos);

            if (modoTela == "Visualizacao")
                DesativarCampos();

        }

        private void DesativarCampos()
        {
            ValorKmRodado_PlanoDiario.Enabled = false;
            ValorPorDia_PlanoDiario.Enabled = false;
            ValorKmRodado_PlanoKmControlado.Enabled = false;
            KmLivreIncluso_PlanoKmControlado.Enabled = false;
            ValorPorDia_PlanoKmControlado.Enabled = false;
            ValorPorDia_PlanoKmLivre.Enabled = false;
            comboBoxGrupoVeiculos.Enabled = false;
            btnCancelar.Text = "Ok";
            btnSalvar.Visible = false;
        }

        private void CarregarGrupoDeVeiculos(List<GrupoDeVeiculos> grupoDeVeiculos)
        {
            comboBoxGrupoVeiculos.Items.Clear();

            foreach (var item in grupoDeVeiculos)
            {
                comboBoxGrupoVeiculos.Items.Add(item);
            }
        }

        public Func<PlanoDeCobranca, Result<PlanoDeCobranca>> GravarRegistro { get; set; }

        private PlanoDeCobranca planoDeCobranca;

        public PlanoDeCobranca PlanoDeCobranca
        {
            get { return planoDeCobranca; }
            set
            {
                planoDeCobranca = value;


                ValorKmRodado_PlanoDiario.Text = planoDeCobranca.ValorKmRodado_PlanoDiario.ToString();
                ValorPorDia_PlanoDiario.Text = planoDeCobranca.ValorPorDia_PlanoDiario.ToString();
                ValorKmRodado_PlanoKmControlado.Text = planoDeCobranca.ValorKmRodado_PlanoKmControlado.ToString();
                KmLivreIncluso_PlanoKmControlado.Text = planoDeCobranca.KmLivreIncluso_PlanoKmControlado.ToString();
                ValorPorDia_PlanoKmControlado.Text = planoDeCobranca.ValorPorDia_PlanoKmControlado.ToString();
                ValorPorDia_PlanoKmLivre.Text = planoDeCobranca.ValorPorDia_PlanoKmLivre.ToString();
                comboBoxGrupoVeiculos.SelectedItem = planoDeCobranca.GrupoDeVeiculos;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            planoDeCobranca.ValorKmRodado_PlanoDiario = Convert.ToDecimal(ValorKmRodado_PlanoDiario.Text);
            planoDeCobranca.ValorPorDia_PlanoDiario = Convert.ToDecimal(ValorPorDia_PlanoDiario.Text);
            planoDeCobranca.ValorKmRodado_PlanoKmControlado = Convert.ToDecimal(ValorKmRodado_PlanoKmControlado.Text);
            planoDeCobranca.KmLivreIncluso_PlanoKmControlado = Convert.ToDecimal(KmLivreIncluso_PlanoKmControlado.Text);
            planoDeCobranca.ValorPorDia_PlanoKmControlado = Convert.ToDecimal(ValorPorDia_PlanoKmControlado.Text);
            planoDeCobranca.ValorPorDia_PlanoKmLivre = Convert.ToDecimal(ValorPorDia_PlanoKmLivre.Text);
            planoDeCobranca.GrupoDeVeiculos = (GrupoDeVeiculos)comboBoxGrupoVeiculos.SelectedItem;

            var resultadoValidacao = GravarRegistro(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Cadastro Plano de Cobrança.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    MessageBox.Show(erro,
                  "Cadastro Plano de Cobrança.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
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
