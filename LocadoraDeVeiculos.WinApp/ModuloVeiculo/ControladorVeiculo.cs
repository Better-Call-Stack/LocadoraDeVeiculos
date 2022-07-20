using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private TabelaVeiculoControl tabelaVeiculo;
        private ServicoVeiculo servicoVeiculo;
        private ServicoGrupoVeiculos servicoGrupoVeiculos;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;

        }
        public override void Inserir()
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo("Cadastro", servicoGrupoVeiculos.SelecionarTodos().Value);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }
        
        public override void Editar()
        {
            var id = tabelaVeiculo.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Nenhum veículo selecionado.",
                    "Edição de dados do veículo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de dados do veículo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroVeiculo("Edição", servicoGrupoVeiculos.SelecionarTodos().Value);

            tela.Veiculo = veiculoSelecionado.Clonar();

            tela.GravarRegistro = servicoVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var id = tabelaVeiculo.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Nenhum veículo selecionado",
                    "Exclusão de dados do veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de dados do veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (veiculoSelecionado.StatusVeiculo == StatusVeiculoEnum.Ativo ||
                veiculoSelecionado.StatusVeiculo == StatusVeiculoEnum.Manutenção)
            {
                MessageBox.Show("Só é possível excluir os dados de veículos inativos.",
                    "Veículo em uso.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente excluir os dados?", "Exclusão de veículo.",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Veículo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculo = new TabelaVeiculoControl(servicoVeiculo, servicoGrupoVeiculos);

            CarregarVeiculos();

            return tabelaVeiculo;
        }

        private void CarregarVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                tabelaVeiculo.AtualizarRegistros(veiculos);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Visualização de Veículos.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
