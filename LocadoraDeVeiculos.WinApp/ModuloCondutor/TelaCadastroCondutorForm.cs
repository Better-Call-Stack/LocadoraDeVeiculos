using FluentResults;
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
        List<Cliente> listaClientes;
        public TelaCadastroCondutorForm( List<Cliente> listaClientes, string modoTela)
        {
            InitializeComponent();

            this.listaClientes = listaClientes;

            InicializaComboBox();

            if (modoTela == "Visualizacao")
            {
                DesativarCampos();
            }
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
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            datePicker.Enabled = false;
        }

        private void InicializaComboBox()
        {
            foreach (Cliente c in listaClientes)
            {
                cbxCliente.Items.Add(c);
            }
        }

        public Func<Condutor,Result<Condutor>> GravarRegistro { get; set; }

        private Condutor condutor;

        public Condutor Condutor
        {
            get { return condutor; }
            set
            {
                condutor = value;

                cbxCliente.SelectedItem = condutor.Cliente;

                txtNome.Text = condutor.Nome;
                txtEmail.Text = condutor.Email;
                txtCPF.Text = condutor.CPF;
                txtCNH.Text = condutor.CNH;
                txtTelefone.Text = condutor.Telefone;
                txtCidade.Text = condutor.Cidade;
                txtEndereco.Text = condutor.Endereco;

                if (condutor.ValidadeCNH != new DateTime(01 , 01 , 0001 , 00,00,00))
                    datePicker.Value = condutor.ValidadeCNH;
            }


        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            condutor.Cliente = (Cliente)cbxCliente.SelectedItem;
            condutor.Nome = txtNome.Text;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = txtTelefone.Text;
            condutor.Cidade = txtCidade.Text;
            condutor.Endereco = txtEndereco.Text;
            condutor.Email = txtEmail.Text;
            condutor.CNH = txtCNH.Text;
            condutor.CPF = txtCPF.Text;
            condutor.ValidadeCNH = datePicker.Value;


            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                      "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
        }

    }
}
