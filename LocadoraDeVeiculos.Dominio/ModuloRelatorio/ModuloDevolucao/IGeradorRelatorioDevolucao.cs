using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloRelatorio.ModuloDevolucao
{
    public interface IGeradorRelatorioDevolucao
    {
        public void GerarRelatorioDevolucaoPDF(Devolucao devolucao);
    }
}
