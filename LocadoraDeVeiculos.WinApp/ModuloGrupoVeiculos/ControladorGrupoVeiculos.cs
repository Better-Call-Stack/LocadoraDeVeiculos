using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.GrupoVeiculos
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private TabelaGrupoVeiculosControl tabelaGrupoVeiculos;
        private readonly ServicoGrupoVeiculos servicoGrupoVeiculos;


        public ControladorGrupoVeiculos(ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoVeiculosForm();
            tela.GrupoDeVeiculos = new GrupoDeVeiculos();

            tela.GravarRegistro = servicoGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Editar()
        {
            var id = tabelaGrupoVeiculos.ObtemIdGrupoVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veiculos primeiro",
                    "Edição do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoVeiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroGrupoVeiculosForm();

            tela.GrupoDeVeiculos = grupoVeiculoSelecionado.Clonar();

            tela.GravarRegistro = servicoGrupoVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupoVeiculos();
        }

        public override void Excluir()
        {
            var id = tabelaGrupoVeiculos.ObtemIdGrupoVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veiculos primeiro",
                    "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoVeiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Grupo de Veiculos?", "Exclusão do Grupo de Veiculos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoVeiculos.Excluir(grupoVeiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoVeiculos == null)
                tabelaGrupoVeiculos = new TabelaGrupoVeiculosControl();

            CarregarGrupoVeiculos();

            return tabelaGrupoVeiculos;
        }

        public override ConfiguracaoToolboxGrupoDeVeiculos ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxGrupoDeVeiculos();
        }

        private void CarregarGrupoVeiculos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            if(resultado.IsSuccess)
            {
                List<GrupoDeVeiculos> grupoDeVeiculos = resultado.Value;

                tabelaGrupoVeiculos.AtualizarRegistros(grupoDeVeiculos);
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão do Grupo de Veiculos", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private GrupoDeVeiculos ObtemGrupoDeVeiculoSelecionado()
        {
            var id = tabelaGrupoVeiculos.ObtemIdGrupoVeiculoSelecionado();

            return repositorioGrupoVeiculos.SelecionarPorId(id);
        }*/

      
    }
}
