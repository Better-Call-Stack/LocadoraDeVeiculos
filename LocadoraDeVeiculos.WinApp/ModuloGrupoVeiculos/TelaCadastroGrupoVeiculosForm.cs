using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentResults;
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

        public Func<GrupoDeVeiculos, Result<GrupoDeVeiculos>> GravarRegistro { get; set; }

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

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            grupoDeVeiculos.Nome = txtNome.Text;
        
            var resultadoValidacao = GravarRegistro(grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if(erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção grupo de veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
        }  
    }
}
