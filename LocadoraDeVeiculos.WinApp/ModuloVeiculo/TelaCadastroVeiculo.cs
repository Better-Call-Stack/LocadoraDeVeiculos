using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
        }

        private Veiculo veiculo;

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get { return veiculo; }
            set
            {
                veiculo = value;

                
            }
        }
    }
}
