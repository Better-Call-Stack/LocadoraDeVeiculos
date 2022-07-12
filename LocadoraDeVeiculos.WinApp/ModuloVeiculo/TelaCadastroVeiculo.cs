using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        string origemCompleto = "";
        string foto = "";
        string pastaDestino = "";
        string destinoCompleto = caminhoFoto;
        private static string caminho = @"C:";
        private static string caminhoFoto = caminho + @"\foto\";

        public TelaCadastroVeiculo(string modoTela, List<GrupoDeVeiculos> grupoDeVeiculos)
        {
            InitializeComponent();
            CarregarCombustivelVeiculo();
            CarregarStatusVeiculo();
            CarregarGrupoDeVeiculos(grupoDeVeiculos);

            if (modoTela == "Visualizacao")
            {
                DesativarCampos();
            }
        }

        private Veiculo veiculo;

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get { return veiculo; }
            set
            {
                veiculo = value;

                txtFabricanteVeiculo.Text = veiculo.Fabricante;
                txtModeloVeiculo.Text = veiculo.Modelo;
                txtCorVeiculo.Text = veiculo.Cor;
                cmbCombustivelVeiculo.SelectedItem = veiculo.TipoCombustivel;
                txtPlacaVeiculo.Text = veiculo.Placa;
                numCapTanqueVeiculo.Value = veiculo.CapacidadeTanque;
                numAnoVeiculo.Value= veiculo.Ano;
                numKmVeiculo.Value = veiculo.KmPercorrido;
                cmbStatusVeiculo.SelectedItem = veiculo.StatusVeiculo;
                cmbGrupoVeiculo.SelectedItem = veiculo.Grupo;
                pb_Veiculo.ImageLocation = veiculo.FotoVeiculo;
            }
        }

        private void CarregarCombustivelVeiculo()
        {
            var opcoes = Enum.GetValues(typeof(TipoCombustivelEnum));

            foreach (var item in opcoes)
            {
                cmbCombustivelVeiculo.Items.Add(item);
            }
        }

        private void CarregarStatusVeiculo()
        {
            var status = Enum.GetValues(typeof(StatusVeiculoEnum));

            foreach (var item in status)
            {
                cmbStatusVeiculo.Items.Add(item);
            }
        }
        private void CarregarGrupoDeVeiculos(List<GrupoDeVeiculos> grupoDeVeiculos)
        {
            cmbGrupoVeiculo.Items.Clear();

            foreach (var item in grupoDeVeiculos)
            {
                cmbGrupoVeiculo.Items.Add(item);
            }
        }

        private void btnSalvarVeiculo_Click(object sender, EventArgs e)
        {
            if(destinoCompleto == "")
            {
                if (MessageBox.Show("Nenhuma foto selecionada, cadastrar sem foto?", "Erro", 
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            if(destinoCompleto != "")
            {
                File.Copy(origemCompleto, destinoCompleto, true);

                if (File.Exists(destinoCompleto))
                {
                    pb_Veiculo.ImageLocation = destinoCompleto;
                }
                else
                {
                    if (MessageBox.Show("Erro ao selecionar foto, deseja continuar?", "Erro", 
                        MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }
            veiculo.Modelo = txtModeloVeiculo.Text;
            veiculo.Fabricante = txtFabricanteVeiculo.Text;
            veiculo.Placa = txtPlacaVeiculo.Text;
            veiculo.Cor = txtCorVeiculo.Text;
            veiculo.TipoCombustivel = (TipoCombustivelEnum)cmbCombustivelVeiculo.SelectedItem;
            veiculo.CapacidadeTanque = numCapTanqueVeiculo.Value;
            veiculo.Ano = (int)numAnoVeiculo.Value;
            veiculo.KmPercorrido = (int)numKmVeiculo.Value;
            veiculo.StatusVeiculo = (StatusVeiculoEnum)cmbStatusVeiculo.SelectedItem;
            veiculo.Grupo = (GrupoDeVeiculos)cmbGrupoVeiculo.SelectedItem;
            veiculo.FotoVeiculo = destinoCompleto;

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro, "Erro");

                DialogResult = DialogResult.None;
            }
        }

        private void DesativarCampos()
        {
            btnCancelarVeiculo.Text = "Ok";
            btnSalvarVeiculo.Visible = false;
            txtFabricanteVeiculo.Enabled = false;
            txtCorVeiculo.Enabled = false;
            txtPlacaVeiculo.Enabled = false;
            txtModeloVeiculo.Enabled = false;
            numCapTanqueVeiculo.Enabled = false;
            numKmVeiculo.Enabled = false;
            numAnoVeiculo.Enabled = false;
            cmbCombustivelVeiculo.Enabled = false;
            cmbGrupoVeiculo.Enabled = false;
            cmbStatusVeiculo.Enabled = false;
            btnAddFotoVeiculo.Enabled = false;

        }
        
        private void btnAddFotoVeiculo_Click(object sender, EventArgs e)
        {
            origemCompleto = "";
            foto = "";
            pastaDestino = caminhoFoto;
            destinoCompleto = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                origemCompleto = openFileDialog1.FileName;
                foto = openFileDialog1.SafeFileName;
                destinoCompleto = pastaDestino + foto;
            }

            if (File.Exists(destinoCompleto))
            {
                if (MessageBox.Show("Arquivo já existe. Deseja substituir?", "Substituir", 
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
           
            pb_Veiculo.ImageLocation = origemCompleto;
        }
    }
}
