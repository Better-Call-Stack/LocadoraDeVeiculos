using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
