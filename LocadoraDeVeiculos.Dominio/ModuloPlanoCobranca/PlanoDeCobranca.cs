using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public PlanoDeCobranca()
        {

        }

        public GrupoDeVeiculos GrupoDeVeiculos { get; set; }

        public decimal ValorKmRodado_PlanoDiario { get; set; }

        public decimal ValorPorDia_PlanoDiario { get; set; }

        public decimal ValorKmRodado_PlanoKmControlado { get; set; }

        public decimal KmLivreIncluso_PlanoKmControlado { get; set; }

        public decimal ValorPorDia_PlanoKmControlado { get; set; }

        public decimal ValorPorDia_PlanoKmLivre { get; set; }

        public PlanoDeCobranca(decimal valorKmRodado_PlanoDiario, decimal valorPorDia_PlanoDiario, decimal valorKmRodado_PlanoKmControlado, decimal kmLivreIncluso_PlanoKmControlado,
        decimal valorPorDia_PlanoKmControlado, decimal valorPorDia_PlanoKmLivre, GrupoDeVeiculos grupoDeVeiculos)
        {
            ValorKmRodado_PlanoDiario = valorKmRodado_PlanoDiario;
            ValorPorDia_PlanoDiario = valorPorDia_PlanoDiario;
            ValorKmRodado_PlanoKmControlado = valorKmRodado_PlanoKmControlado;
            KmLivreIncluso_PlanoKmControlado = kmLivreIncluso_PlanoKmControlado;
            ValorPorDia_PlanoKmControlado = valorPorDia_PlanoKmControlado;
            ValorPorDia_PlanoKmLivre = valorPorDia_PlanoKmLivre;
            GrupoDeVeiculos = grupoDeVeiculos;
        }

        public override void Atualizar(PlanoDeCobranca registro)
        {
            ValorKmRodado_PlanoDiario = registro.ValorKmRodado_PlanoDiario;
            ValorPorDia_PlanoDiario = registro.ValorPorDia_PlanoDiario;
            ValorKmRodado_PlanoKmControlado = registro.ValorKmRodado_PlanoKmControlado;
            KmLivreIncluso_PlanoKmControlado = registro.KmLivreIncluso_PlanoKmControlado;
            ValorPorDia_PlanoKmControlado = registro.ValorPorDia_PlanoKmControlado;
            ValorPorDia_PlanoKmLivre = registro.ValorPorDia_PlanoKmLivre;
            ValorPorDia_PlanoKmLivre = registro.ValorPorDia_PlanoKmLivre;
            GrupoDeVeiculos = registro.GrupoDeVeiculos;
        }



        public PlanoDeCobranca Clonar()
        {
            return MemberwiseClone() as PlanoDeCobranca;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(ValorKmRodado_PlanoDiario);
            hash.Add(ValorPorDia_PlanoDiario);
            hash.Add(ValorKmRodado_PlanoKmControlado);
            hash.Add(KmLivreIncluso_PlanoKmControlado);
            hash.Add(ValorPorDia_PlanoKmControlado);
            hash.Add(ValorPorDia_PlanoKmLivre);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id == cobranca.Id &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoDeVeiculos, cobranca.GrupoDeVeiculos) &&
                   ValorKmRodado_PlanoDiario == cobranca.ValorKmRodado_PlanoDiario &&
                   ValorPorDia_PlanoDiario == cobranca.ValorPorDia_PlanoDiario &&
                   ValorKmRodado_PlanoKmControlado == cobranca.ValorKmRodado_PlanoKmControlado &&
                   KmLivreIncluso_PlanoKmControlado == cobranca.KmLivreIncluso_PlanoKmControlado &&
                   ValorPorDia_PlanoKmControlado == cobranca.ValorPorDia_PlanoKmControlado &&
                   ValorPorDia_PlanoKmLivre == cobranca.ValorPorDia_PlanoKmLivre;
        }
    }
}

