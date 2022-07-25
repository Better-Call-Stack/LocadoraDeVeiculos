using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
            CarregarPerfilFuncionario();
        }

        private Funcionario funcionario;

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                txtNomeFuncionario.Text = funcionario.Nome;
                txtCPFFuncionario.Text = funcionario.CPF;
                txtAdmissaoFuncionario.Value = funcionario.DataDeAdmissao;
                txtLoginFuncionario.Text = funcionario.Login;
                txtSenhaFuncionario.Text = funcionario.Senha;
                cmbPerfilFuncionario.SelectedItem = funcionario.Perfil;
            }
        }

        private void CarregarPerfilFuncionario()
        {
            var perfis = Enum.GetValues(typeof(PerfilEnum));

            foreach (var item in perfis)
            {
                cmbPerfilFuncionario.Items.Add(item);
            }
        }

        private void btnSalvarFuncionario_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txtNomeFuncionario.Text;
            funcionario.CPF = txtCPFFuncionario.Text;
            funcionario.DataDeAdmissao = txtAdmissaoFuncionario.Value;
            funcionario.Salario = txtSalario.Value;
            funcionario.Login = txtLoginFuncionario.Text;
            funcionario.Senha = txtSenhaFuncionario.Text;
            funcionario.Perfil = (PerfilEnum)cmbPerfilFuncionario.SelectedItem;

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Cadastro de Colaborador.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(erro,
                   "Cadastro de Colaborador.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }
            }
        }
       
    }
}
