using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        private Funcionario funcionario;

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }
    }
}
