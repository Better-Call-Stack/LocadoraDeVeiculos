using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa
{
    public class Taxa : EntidadeBase<Taxa>
    {
        TipoCalculoTaxa tipoCalculoTaxa;

        public string Nome { get; set; }
        public decimal Valor { get; set; }
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

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   tipoCalculoTaxa == taxa.tipoCalculoTaxa &&
                   Nome == taxa.Nome &&
                   Valor == taxa.Valor &&
                   Tipo == taxa.Tipo;
        }

        public override string ToString()
        {
            return Nome.PadRight(30) + " Valor: " + Valor + "  Tipo: " + Tipo;
        }
    }
}
