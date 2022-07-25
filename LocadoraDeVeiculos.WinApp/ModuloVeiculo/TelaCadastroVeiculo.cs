using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using FluentResults;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        byte[] imagemSelecionada;

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

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

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
                imagemSelecionada = veiculo.FotoVeiculo;
                pb_Veiculo.Image = veiculo.Imagem;
  
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
            veiculo.FotoVeiculo = imagemSelecionada;

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Cadastro de Veículo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(erro,
                  "Cadastro de Veículo.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }
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
            imagemSelecionada = veiculo.FotoVeiculo;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagemSelecionada = File.ReadAllBytes(openFileDialog1.FileName);
                using (var ms = new MemoryStream(imagemSelecionada)) 
                    pb_Veiculo.Image = new Bitmap(ms);
            }
        }
    }
}
