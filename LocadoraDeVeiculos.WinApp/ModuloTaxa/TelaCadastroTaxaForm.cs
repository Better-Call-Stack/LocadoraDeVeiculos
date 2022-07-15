using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
        }

        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        private Taxa taxa;

        public Taxa Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;


                txtNome.Text = taxa.Nome;
                txtValor.Text = taxa.Valor.ToString();
                cbxTipoCalculo.SelectedItem = taxa.Tipo.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            taxa.Nome = txtNome.Text;
            taxa.Valor = Decimal.Parse(txtValor.Text);

            if (cbxTipoCalculo.SelectedItem == "Diario")
            {
                taxa.Tipo = TipoCalculoTaxa.Diario;
            }
            else
                taxa.Tipo = TipoCalculoTaxa.Fixo;


            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Erro");

                DialogResult = DialogResult.None;
            }
        }
    }
}
