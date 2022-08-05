using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloRelatorio
{
    public interface IGeradorRelatorio
    {
        public void GerarRelatorioPdf();

    }
}
