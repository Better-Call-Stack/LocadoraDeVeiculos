using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
    public partial class TabelaClientesControl : UserControl
    {
        public TabelaClientesControl()
        {
            InitializeComponent();
            gridPessoaFisica.ConfigurarGridZebrado();
            gridPessoaFisica.ConfigurarGridSomenteLeitura();
        }

        internal void AtualizarRegistros(List<Cliente> clientes)
        {
            gridPessoaFisica.Rows.Clear();

            foreach (var c in clientes)
            {
                gridPessoaFisica.Rows.Add(c.Id, c.Nome, c.CPF, c.Telefone, c.Email);
            }
        }

        public int ObtemIdClienteSelecionado()
        {
            return gridPessoaFisica.SelecionarId<int>();
        }
    }
}
