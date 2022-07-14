using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly RepositorioVeiculo repositorioVeiculo;
        private TabelaVeiculoControl tabelaVeiculo;
        private ServicoVeiculo servicoVeiculo;
        private RepositorioGrupoVeiculos repositorioGrupoVeiculos;

        public ControladorVeiculo(RepositorioVeiculo repositorioVeiculo, ServicoVeiculo servicoVeiculo, RepositorioGrupoVeiculos repositorioGrupoVeiculos)
        {
            this.repositorioVeiculo=repositorioVeiculo;
            this.servicoVeiculo=servicoVeiculo;
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;

        }
        public override void Inserir()
        {
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo("Cadastro", repositorioGrupoVeiculos.SelecionarTodos());
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
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Edição de dados do veículo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaCadastroVeiculo tela = new TelaCadastroVeiculo("Edição", repositorioGrupoVeiculos.SelecionarTodos());

            tela.Veiculo = veiculoSelecionado.Clonar();

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }
        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Exclusão de dados de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (veiculoSelecionado.StatusVeiculo == StatusVeiculoEnum.Ativo ||
                veiculoSelecionado.StatusVeiculo == StatusVeiculoEnum.Manutenção)
            {
                MessageBox.Show("Só é possível excluir os dados de veículos inativos.",
                    "Veículo em uso.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir os dados?",
                    "Exclusão de dados de veículo.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioVeiculo.Excluir(veiculoSelecionado);
                CarregarVeiculos();
            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            tabelaVeiculo = new TabelaVeiculoControl(repositorioVeiculo, repositorioGrupoVeiculos);

            CarregarVeiculos();

            return tabelaVeiculo;
        }
        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);
        }
        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = tabelaVeiculo.ObtemIdVeiculoSelecionado();
            return repositorioVeiculo.SelecionarPorId(id);
        }

        //private bool ValidarVeiculoParaExcluir()
        //{

        //}
    }
}
