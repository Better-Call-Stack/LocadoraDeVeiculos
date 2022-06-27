using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;


namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos
{
    public partial class TelaCadastroGrupoVeiculosForm : Form
    {
        private GrupoDeVeiculos grupoDeVeiculos;

        public TelaCadastroGrupoVeiculosForm()
        {
            InitializeComponent();
        }
        public Func<GrupoDeVeiculos, ValidationResult> GravarRegistro { get; set; }

        public GrupoDeVeiculos GrupoDeVeiculos
        {
            get 
            { 
                return grupoDeVeiculos; 
            }
            set
            {
                grupoDeVeiculos = value;
                txtNome.Text = grupoDeVeiculos.Nome;
                txtValorPlanoDiario.Text = grupoDeVeiculos.ValorPlanoDiario.ToString();
                txtValorDiariaKmControlado.Text = grupoDeVeiculos.ValorDiariaKmControlado.ToString();
                txtValorDiariaKmLivre.Text = grupoDeVeiculos.ValorDiarioKmLivre.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            grupoDeVeiculos.Nome = txtNome.Text;
            grupoDeVeiculos.ValorPlanoDiario = Convert.ToDecimal(txtValorPlanoDiario.Text);
            grupoDeVeiculos.ValorDiariaKmControlado = Convert.ToDecimal(txtValorDiariaKmControlado.Text);
            grupoDeVeiculos.ValorDiarioKmLivre = Convert.ToDecimal(txtValorDiariaKmLivre.Text);

            var resultadoValidacao = GravarRegistro(grupoDeVeiculos);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;


                DialogResult = DialogResult.None;
            }

        }
    }
}
