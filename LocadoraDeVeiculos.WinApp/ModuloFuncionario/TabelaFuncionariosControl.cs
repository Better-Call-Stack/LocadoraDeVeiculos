using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionariosControl : UserControl
    {
        RepositorioFuncionario repositorio;
        public TabelaFuncionariosControl(RepositorioFuncionario repositorio)
        {
            InitializeComponent();
            GridFuncionarios.ConfigurarGridZebrado();
            GridFuncionarios.ConfigurarGridSomenteLeitura();
            GridFuncionarios.Columns.AddRange(ObterColunas());
            GridFuncionarios.ConfigurarColunaId();
            this.repositorio = repositorio;
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "IDFuncionario", HeaderText = "Matricula"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPFFuncionario", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeFuncionario", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDeAdmissaoFuncionario", HeaderText = "Data de Admissão"},

                new DataGridViewTextBoxColumn { DataPropertyName = "SalarioFuncionario", HeaderText = "Salario"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PerfilFuncionario", HeaderText = "Perfil"},

                new DataGridViewTextBoxColumn { DataPropertyName = "LoginFuncionario", HeaderText = "Login"},
            };

            return colunas;
        }

        public Guid ObtemIdFuncionarioSelecionado()
        {
            return GridFuncionarios.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            GridFuncionarios.Rows.Clear();

            foreach (Funcionario f in funcionarios)
            {
                GridFuncionarios.Rows.Add(f.Id, f.CPF, f.Nome, f.DataDeAdmissao.ToShortDateString(), f.Salario, f.Perfil, f.Login);
            }
        }

    }
}
