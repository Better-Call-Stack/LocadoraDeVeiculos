using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        TipoCalculoTaxa tipoCalculoTaxa;

        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public List<Locacao> Locacoes { get; set; }
        public TipoCalculoTaxa Tipo
        {
            get { return tipoCalculoTaxa; }
            set
            {
                tipoCalculoTaxa = value;

            }
        }

        public Taxa Clonar()
        {
            return MemberwiseClone() as Taxa;
        }

        public override void Atualizar(Taxa registro)
        {
            throw new NotImplementedException();
        }



        public override string ToString()
        {
            return Nome.PadRight(30) + " Valor: " + Valor + "  Tipo: " + Tipo;
        }

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   Id.Equals(taxa.Id) &&
                   tipoCalculoTaxa == taxa.tipoCalculoTaxa &&
                   Nome == taxa.Nome &&
                   Valor == taxa.Valor &&
                   EqualityComparer<List<Locacao>>.Default.Equals(Locacoes, taxa.Locacoes) &&
                   Tipo == taxa.Tipo;
        }
    }
}
