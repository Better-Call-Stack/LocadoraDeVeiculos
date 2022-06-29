using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {


        public TelaCadastroClienteForm(string modoTela)
        {
            InitializeComponent();

            if (modoTela == "Visualizacao")
            {
                DesativarCampos();
            }
        }

        private void DesativarCampos()
        {
            btnCancelar.Text = "Ok";
            btnSalvar.Visible = false;

            cbxPessoa.Enabled = false;
            txtNome.Enabled = false;
            txtCpfCnpj.Enabled = false;
            txtCNH.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false; 
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;

        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;

                if(cliente.Id != 0)
                    cbxPessoa.Enabled = false;

                if (cliente.TipoPessoa == TipoPessoa.Fisica)
                {
                    cbxPessoa.Text = "Física";
                    txtCpfCnpj.Text = cliente.CPF;
                    txtCNH.Text = cliente.CNH;
                }
                else
                {
                    cbxPessoa.Text = "Jurídica";
                    txtCpfCnpj.Text = cliente.CNPJ;
                }


                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
                txtCidade.Text = cliente.Cidade;
                txtEndereco.Text = cliente.Endereco;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if(cbxPessoa.SelectedItem == "Física")
            {
                cliente.TipoPessoa = TipoPessoa.Fisica;
                cliente.CPF = txtCpfCnpj.Text;
                cliente.CNH = txtCNH.Text;
            }
            else
            {
                cliente.TipoPessoa = TipoPessoa.Juridica;
                cliente.CNPJ = txtCpfCnpj.Text;
            }

            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Email = txtEmail.Text;


            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Erro");
               // TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cbxPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPessoa.SelectedItem == "Física")
            {
                txtCpfCnpj.Mask = "999.999.999-99";
                labelCpfCnpj.Text = "CPF:";
                txtCNH.Enabled = true;
            }

            if (cbxPessoa.SelectedItem == "Jurídica") {
                txtCpfCnpj.Mask = "99.999.999/9999-99";
                labelCpfCnpj.Text = "CNPJ:";
                txtCNH.Enabled = false;
            }
        }
    }
}
