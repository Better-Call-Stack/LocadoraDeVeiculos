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
        
        public TabelaFuncionariosControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

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
            return grid.SelecionarId<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario f in funcionarios)
            {
                grid.Rows.Add(f.Id, f.CPF, f.Nome, f.DataDeAdmissao.ToShortDateString(), f.Salario, f.Perfil, f.Login);
            }
        }

    }
}
