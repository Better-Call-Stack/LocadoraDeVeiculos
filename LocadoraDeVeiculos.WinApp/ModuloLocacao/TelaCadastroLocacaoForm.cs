using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private ServicoCliente servicoCliente;
        private ServicoVeiculo servicoVeiculo;
        private ServicoCondutor servicoCondutor;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;
        private ServicoPlanoDeCobranca servicoPlano;
        private ServicoTaxa servicoTaxa;
             
        private Cliente cliente;
        private Veiculo veiculo;
        private GrupoDeVeiculos grupo;
        private PlanoDeCobranca plano;
        private List<Taxa> taxas = new List<Taxa>();

        public TelaCadastroLocacaoForm(ServicoCliente servicoCliente, ServicoVeiculo servicoVeiculo,
            ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoCondutor servicoCondutor, ServicoPlanoDeCobranca servicoPlano
            ,ServicoTaxa servicoTaxa)
        {
            InitializeComponent();
            this.servicoCliente = servicoCliente;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoCondutor = servicoCondutor;
            this.servicoPlano = servicoPlano;
            this.servicoTaxa = servicoTaxa;

            PovoarCbxGrupoVeiculos();
            AtualizarValoresPlano();
            PovoarTaxas();

            dpDevolucao.Value.AddDays(30);
        }


        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        private Locacao locacao;

        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                if(locacao.Cliente != null)
                {
                    cbxPlanoCobranca.Enabled = true;
                    cbxCondutor.Enabled = true;


                    txtCliente.Text = locacao.Cliente.Nome;
                    cliente = locacao.Cliente;


                    PovoarCbxCondutor();
                    cbxCondutor.SelectedItem = locacao.Condutor;

                    cbxGrupoVeiculos.SelectedItem = locacao.Veiculo.Grupo;
                    AtualizarValoresPlano();

                    int i = 0;
                    foreach (var item in cbxPlanoCobranca.Items)
                    {
                        if (item.Equals(locacao.PlanoSelecionado))
                            cbxPlanoCobranca.SelectedItem = cbxPlanoCobranca.Items[i];

                        i++;
                    }


                    txtVeiculo.Text = locacao.Veiculo.Modelo;
                    veiculo = locacao.Veiculo;

                    int posicao = 0;
                    foreach (var taxaLocacao in locacao.Taxas)
                    {
                        for(int j = 0; j < clbTaxas.Items.Count; j++)
                        {
                            if (taxaLocacao == clbTaxas.Items[j])
                                clbTaxas.SetItemChecked(posicao, true);

                            posicao++;
                        }
                        posicao = 0;
                    }

                    dpLocacao.Value = locacao.DataLocacao;
                    dpDevolucao.Value = locacao.PrevisaoDevolucao;

                }
            }
        }
       
        private void PovoarCbxGrupoVeiculos()
        {
            var grupos = servicoGrupoVeiculos.SelecionarTodos().Value;

            if (grupos.Any())
                btnSelecionarVeiculo.Enabled = true;

            foreach (var grupo in grupos)
            {
                cbxGrupoVeiculos.Items.Add(grupo);
            }
        }

        private void PovoarTaxas()
        {
            var resultadoSelecao = servicoTaxa.SelecionarTodos();


            if (resultadoSelecao.IsSuccess)
            {
                List<Taxa> taxas = servicoTaxa.SelecionarTodos().Value;


                foreach (var taxa in taxas)
                {
                    if(taxa.Tipo == TipoCalculoTaxa.Diario)
                        clbTaxas.Items.Add(taxa);
                } 
                
                foreach (var taxa in taxas)
                {
                    if(taxa.Tipo == TipoCalculoTaxa.Fixo)
                        clbTaxas.Items.Add(taxa);
                }
            }
        }
       
        private void PovoarCbxCondutor()
        {
            cbxCondutor.Items.Clear();

            var resultadoSelecao = servicoCondutor.SelecionarTodos();

            if (resultadoSelecao.IsSuccess)
            {
                foreach (var c in servicoCondutor.SelecionarTodos().Value)
                {
                    if (c.Cliente.Id == cliente.Id)
                        cbxCondutor.Items.Add(c);
                }
            }
        }
        
        private void ObtemPlanoCobranca()
        {
            foreach (var p in servicoPlano.SelecionarTodos().Value)
            {
                if (p.GrupoDeVeiculos == grupo)
                    plano = p;
            }
        }
       

        private void btnSelecionarCliente_Click(object sender, EventArgs e)
        {
            BotaoSelecionarForm tela = new BotaoSelecionarForm(servicoCliente);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.Cancel)
                return;

            if(resultado == DialogResult.OK)
            {
                cliente = tela.cliente;
                txtCliente.Text = cliente.Nome;
                cbxCondutor.Enabled = true;
                PovoarCbxCondutor();
            }
        }

        private void btnSelecionarVeiculo_Click(object sender, EventArgs e)
        {
            BotaoSelecionarForm tela = new BotaoSelecionarForm(servicoVeiculo, servicoGrupoVeiculos, grupo);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.Cancel)
                return;

            if (resultado == DialogResult.OK)
            {
                veiculo = tela.veiculo;
                txtVeiculo.Text = veiculo.Modelo;
                cbxPlanoCobranca.Enabled = true;
            }
        }

        
        private void cbxGrupoVeiculos_SelectedValueChanged(object sender, EventArgs e)
        {
             grupo = (GrupoDeVeiculos)cbxGrupoVeiculos.SelectedItem;
             txtVeiculo.Text = "";
             veiculo = null;

            ObtemPlanoCobranca();
        }
        
        private void cbxPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValoresPlano();

            AtualizaValoresSubtotalEhDiaria();

            clbTaxas.Enabled = true;
        }

        


        private void AtualizaValoresSubtotalEhDiaria()
        {
            AtualizaValorDiaria();

            AtualizaSubtotal();
        }

        private void AtualizaSubtotal()
        {
            decimal subtotal = 0;

            decimal totalPorDia = Decimal.Parse(txtTotalPorDia.Text);
            subtotal += totalPorDia;


            TimeSpan diasLocacao = dpDevolucao.Value.Date - dpLocacao.Value.Date;
            subtotal *= diasLocacao.Days;

            foreach (Taxa item in clbTaxas.CheckedItems)
            {
                if (item.Tipo == TipoCalculoTaxa.Fixo)
                    subtotal += item.Valor;
            }


            txtSubtotal.Text = subtotal.ToString();
        }

        private void AtualizaValorDiaria()
        {
            decimal valorTotalPorDia = 0;

            foreach (Taxa item in clbTaxas.CheckedItems)
            {
                if (item.Tipo == TipoCalculoTaxa.Diario)
                    valorTotalPorDia += item.Valor;
            }

            valorTotalPorDia += Decimal.Parse(txtDiaria.Text);

            txtTotalPorDia.Text = valorTotalPorDia.ToString();
        }

        private void AtualizarValoresPlano()
        {

            switch (cbxPlanoCobranca.SelectedItem)
            {

                case "Diário":
                    txtDiaria.Text = plano.ValorPorDia_PlanoDiario.ToString();
                    txtKmRodado.Text = plano.ValorKmRodado_PlanoDiario.ToString();
                    txtKmLivre.Text = "0";
                    return;

                case "Km Controlado":
                    txtDiaria.Text = plano.ValorPorDia_PlanoKmControlado.ToString();
                    txtKmRodado.Text = plano.ValorKmRodado_PlanoKmControlado.ToString();
                    txtKmLivre.Text = plano.KmLivreIncluso_PlanoKmControlado.ToString();
                    return;

                case "Km Livre":
                    txtDiaria.Text = plano.ValorPorDia_PlanoKmLivre.ToString();
                    txtKmRodado.Text = "0";
                    txtKmLivre.Text = "0";
                    return;
            }


        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            locacao.Cliente = cliente;
            locacao.Condutor = (Condutor)cbxCondutor.SelectedItem;
            locacao.PlanoSelecionado = cbxPlanoCobranca.Text;
            locacao.Veiculo = veiculo;
            locacao.PlanoDeCobranca = plano;
            locacao.DataLocacao = dpLocacao.Value;
            locacao.PrevisaoDevolucao = dpDevolucao.Value;
            locacao.StatusLocacao = StatusLocacao.Aberta;
            
            foreach (Taxa taxa in clbTaxas.CheckedItems)
            {
                taxas.Add(taxa);
            }
            locacao.Taxas = taxas;

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro, "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(erro, "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                }

                
            }
        }

        private void dpDevolucao_ValueChanged(object sender, EventArgs e)
        {
            if (dpDevolucao.Value.AddSeconds(1) < dpLocacao.Value)
            {
                MessageBox.Show("Data de locação deve ser menor do que a data de devolução",
                    "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                dpDevolucao.Value = DateTime.Now.AddDays(30);

                return;
            }    
         
            if (dpDevolucao.Value > dpLocacao.Value.AddDays(31))
            {
                MessageBox.Show("Locação pode ter no máximo 30 dias de aluguel",
                    "Inserção locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                dpDevolucao.Value = DateTime.Now.AddDays(30);

                return;
            }

            AtualizaSubtotal();
        }

        private void clbTaxas_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaValoresSubtotalEhDiaria();
        }
    }
}
