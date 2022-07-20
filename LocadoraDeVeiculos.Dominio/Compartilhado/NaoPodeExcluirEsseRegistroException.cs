using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class NaoPodeExcluirEsseRegistroException : Exception
    {
        public NaoPodeExcluirEsseRegistroException(Exception ex) : base("", ex)
        {

        }
    }
}
