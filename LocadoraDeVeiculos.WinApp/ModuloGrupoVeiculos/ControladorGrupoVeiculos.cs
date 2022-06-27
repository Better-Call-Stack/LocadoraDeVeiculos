﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos;
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
        private RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos;
        private TabelaGrupoVeiculosControl tabelaGrupoVeiculos;

        public ControladorGrupoVeiculos(RepositorioGrupoVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoVeiculosForm tela = new TelaCadastroGrupoVeiculosForm();
            tela.GrupoDeVeiculos = new GrupoDeVeiculos();

            tela.GravarRegistro = repositorioGrupoVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Editar()
        {
            GrupoDeVeiculos grupoDeVeiculoSelecionado = ObtemGrupoDeVeiculoSelecionado();

            if (grupoDeVeiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veiculos primeiro",
                "Edição do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoVeiculosForm tela = new TelaCadastroGrupoVeiculosForm();

            tela.GrupoDeVeiculos = grupoDeVeiculoSelecionado.Clonar();

            tela.GravarRegistro = repositorioGrupoVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoVeiculos();
            }
        }

        public override void Excluir()
        {
            GrupoDeVeiculos grupoDeVeiculoSelecionado = ObtemGrupoDeVeiculoSelecionado();

            if (grupoDeVeiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veiculos primeiro",
                "Exclusão do Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o grupo de veiculos?",
                "Exclusão do Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoVeiculos.Excluir(grupoDeVeiculoSelecionado);
                CarregarGrupoVeiculos();
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
            List<GrupoDeVeiculos> grupoDeVeiculos = repositorioGrupoVeiculos.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(grupoDeVeiculos);
        }

        private GrupoDeVeiculos ObtemGrupoDeVeiculoSelecionado()
        {
            var id = tabelaGrupoVeiculos.ObtemIdGrupoVeiculoSelecionado();

            return repositorioGrupoVeiculos.SelecionarPorId(id);
        }

      
    }
}
