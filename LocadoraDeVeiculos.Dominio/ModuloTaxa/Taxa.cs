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

        public override void Atualizar(Taxa registro)
        {
            throw new NotImplementedException();
        }
    }
}
