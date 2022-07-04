using FluentValidation.Results;
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
        public TelaCadastroCondutorForm()
        {
            InitializeComponent();
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        private Condutor condutor;

        public Condutor Condutor
        {
            get { return condutor; }
            set
            {
                condutor = value;



                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
                txtCidade.Text = cliente.Cidade;
                txtEndereco.Text = cliente.Endereco;
                txtEmail.Text = cliente.Email;
            }
        }
    }
}
