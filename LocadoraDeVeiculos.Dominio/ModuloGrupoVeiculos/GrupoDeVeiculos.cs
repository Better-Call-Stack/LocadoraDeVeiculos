using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    [Serializable]
    public class GrupoDeVeiculos : EntidadeBase<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos()
        {

        }

        public GrupoDeVeiculos(string nome, decimal valorPlanoDiario,
            decimal valorDiariaKmControlado, decimal valorDiarioKmLivre)
        {
            Nome = nome;
            ValorPlanoDiario = valorPlanoDiario;
            ValorDiariaKmControlado = valorDiariaKmControlado;
            ValorDiarioKmLivre = valorDiarioKmLivre;
        }
        public string Nome { get; set; }
        public decimal ValorPlanoDiario { get; set; }
        public decimal ValorDiariaKmControlado { get; set; }
        public decimal ValorDiarioKmLivre { get; set; }
        public override string ToString()
        {
            return $"Nome: {Nome}, Valor Plano Diário: {ValorPlanoDiario}, Valor Diaria Km Controlado: {ValorDiariaKmControlado}, Valor Diario Km Livre: {ValorDiarioKmLivre}";
        }

        public GrupoDeVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoDeVeiculos;
        }

        public override void Atualizar(GrupoDeVeiculos registro)
        {
            Nome = registro.Nome;
            ValorPlanoDiario = registro.ValorPlanoDiario;
            ValorDiariaKmControlado = registro.ValorDiariaKmControlado;
            ValorDiarioKmLivre = registro.ValorDiarioKmLivre;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoDeVeiculos controladorGrupoVeiculos &&
                   Nome == controladorGrupoVeiculos.Nome &&
                   ValorPlanoDiario == controladorGrupoVeiculos.ValorPlanoDiario &&
                   ValorDiariaKmControlado == controladorGrupoVeiculos.ValorDiariaKmControlado &&
                   ValorDiarioKmLivre == controladorGrupoVeiculos.ValorDiarioKmLivre;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Nome, ValorPlanoDiario, ValorDiariaKmControlado, ValorDiarioKmLivre);
        }
    }
}
