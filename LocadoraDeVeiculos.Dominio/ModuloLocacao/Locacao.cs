using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {

        private StatusLocacao statusLocacao;

        public DateTime DataLocacao { get; set; }

        public DateTime PrevisaoDevolucao { get; set; }

        public string PlanoSelecionado { get; set; }

        public Veiculo Veiculo { get; set; }
      
        public Guid VeiculoId { get; set; }

        public List<Taxa> Taxas { get; set; }

        public Condutor Condutor { get; set; }

        public Guid CondutorId { get; set; }

        public Cliente Cliente { get; set; }

        public Guid ClienteId { get; set; }
        
        public PlanoDeCobranca PlanoDeCobranca { get; set; }

        public Guid PlanoDeCobrancaId { get; set; }

        public StatusLocacao StatusLocacao
        {
            get { return statusLocacao; }
            set
            {
                statusLocacao = value;

            }
        }

        public override void Atualizar(Locacao registro)
        {
            throw new NotImplementedException();
        }
    }
}
