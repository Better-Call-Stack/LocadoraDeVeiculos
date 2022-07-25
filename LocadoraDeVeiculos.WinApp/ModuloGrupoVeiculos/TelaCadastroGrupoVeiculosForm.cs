using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
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
                    MessageBox.Show(erro, "Inserção grupo de veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }
            }
        }  
    }
}
