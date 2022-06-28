using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private readonly RepositorioFuncionario repositorioFuncionario;
        private TabelaFuncionariosControl tabelaFuncionarios;

        public ControladorFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();
            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um colaborador primeiro",
                "Edição de dados de colaborador.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionario tela = new TelaCadastroFuncionario();

            tela.Funcionario = funcionarioSelecionado.Clonar();

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }

        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um colaborador primeiro",
                "Exclusão de dados de colaborador.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir os dados?",
                "Exclusão de dados de colaborador.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }

        public override UserControl ObtemListagem()
        {
            tabelaFuncionarios = new TabelaFuncionariosControl(repositorioFuncionario);

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxFuncionario();
        }

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = tabelaFuncionarios.ObtemIdFuncionarioSelecionado();

            return repositorioFuncionario.SelecionarPorId((int)id);
        }
        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionarios);

        }
    }
}
