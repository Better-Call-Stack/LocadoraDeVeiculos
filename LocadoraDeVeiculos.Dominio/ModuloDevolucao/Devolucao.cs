using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Devolucao()
        {

        }
        public Locacao Locacao { get; set; }
        public Guid LocacaoId { get; set; }

        public decimal Valor { get; set; }

        public List<Taxa> Taxas { get; set; }

        public decimal ValorGasolina { get; set; }
        public decimal Quilometragem { get; set; }
        public DateTime DataDevolucao { get; set; }

        public string VolumeTanque { get; set; }

        public override void Atualizar(Devolucao registro)
        {
            ValorGasolina = registro.ValorGasolina;
            Quilometragem = registro.Quilometragem;
            DataDevolucao = registro.DataDevolucao;
            Locacao = registro.Locacao;
            LocacaoId = registro.Locacao.Id;
        }
    }
}
