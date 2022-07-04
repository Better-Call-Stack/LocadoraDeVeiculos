using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        public TelaCadastroCondutorForm(string modoTela)
        {
            InitializeComponent();

            if (modoTela == "Visualizacao")
            {
                DesativarCampos();
            }
            InicializaComboBox();

            
        }

        private void DesativarCampos()
        {
            btnCancelar.Text = "Ok";
            btnInserir.Visible = false;
            cbxCliente.Enabled = false;
            txtNome.Enabled = false;
            txtCNH.Enabled = false;
            txtCPF.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false;
            labelTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            datePicker.Enabled = false;
        }

        private void InicializaComboBox()
        {

        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        private Condutor condutor;

        public Condutor Condutor
        {
            get { return condutor; }
            set
            {
                condutor = value;

                cbxCliente.SelectedValue = condutor.Cliente;

                txtNome.Text = condutor.Nome;
                txtEmail.Text = condutor.Email;
                txtCPF.Text = condutor.CPF;
                txtCNH.Text = condutor.CNH;
                datePicker.Value = condutor.ValidadeCNH;
                labelTelefone.Text = condutor.Telefone;
                txtCidade.Text = condutor.Cidade;
                txtEndereco.Text = condutor.Endereco;
            }


        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            condutor.Cliente = (Cliente)cbxCliente.SelectedValue;
            condutor.Nome = txtNome.Text;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = labelTelefone.Text;
            condutor.Cidade = txtCidade.Text;
            condutor.Endereco = txtEndereco.Text;
            condutor.Email = txtEmail.Text;
            condutor.CNH = txtCNH.Text;
            condutor.CPF = txtCPF.Text;
            condutor.ValidadeCNH = datePicker.Value;


            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Erro");

                DialogResult = DialogResult.None;
            }
        }

    }
}
