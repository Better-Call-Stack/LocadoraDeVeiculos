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

        public decimal txtValorKmRodado_PlanoDiario { get; set; }

        public decimal txtValorPorDia_PlanoDiario { get; set; }

        public decimal txtValorKmRodado_PlanoKmControlado { get; set; }

        public decimal txtKmLivreIncluso_PlanoKmControlado { get; set; }

        public decimal txtValorPorDia_PlanoKmControlado { get; set; }

        public decimal txtValorPorDia_PlanoKmLivre { get; set; }

        public PlanoDeCobranca(decimal valorKmRodado_PlanoDiario, decimal valorPorDia_PlanoDiario, decimal valorKmRodado_PlanoKmControlado, decimal kmLivreIncluso_PlanoKmControlado,
        decimal valorPorDia_PlanoKmControlado, decimal valorPorDia_PlanoKmLivre, GrupoDeVeiculos grupoDeVeiculos)
        {
            txtValorKmRodado_PlanoDiario = valorKmRodado_PlanoDiario;
            txtValorPorDia_PlanoDiario = valorPorDia_PlanoDiario;
            txtValorKmRodado_PlanoKmControlado = valorKmRodado_PlanoKmControlado;
            txtKmLivreIncluso_PlanoKmControlado = kmLivreIncluso_PlanoKmControlado;
            txtValorPorDia_PlanoKmControlado = valorPorDia_PlanoKmControlado;
            txtValorPorDia_PlanoKmLivre = valorPorDia_PlanoKmLivre;
            GrupoDeVeiculos = grupoDeVeiculos;
        }

        public override void Atualizar(PlanoDeCobranca registro)
        {
            txtValorKmRodado_PlanoDiario = registro.txtValorKmRodado_PlanoDiario;
            txtValorPorDia_PlanoDiario = registro.txtValorPorDia_PlanoDiario;
            txtValorKmRodado_PlanoKmControlado = registro.txtValorKmRodado_PlanoKmControlado;
            txtKmLivreIncluso_PlanoKmControlado = registro.txtKmLivreIncluso_PlanoKmControlado;
            txtValorPorDia_PlanoKmControlado = registro.txtValorPorDia_PlanoKmControlado;
            txtValorPorDia_PlanoKmLivre = registro.txtValorPorDia_PlanoKmLivre;
            txtValorPorDia_PlanoKmLivre = registro.txtValorPorDia_PlanoKmLivre;
            GrupoDeVeiculos = registro.GrupoDeVeiculos;
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id == cobranca.Id &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoDeVeiculos, cobranca.GrupoDeVeiculos) &&
                   txtValorKmRodado_PlanoDiario == cobranca.txtValorKmRodado_PlanoDiario &&
                   txtValorPorDia_PlanoDiario == cobranca.txtValorPorDia_PlanoDiario &&
                   txtValorKmRodado_PlanoKmControlado == cobranca.txtValorKmRodado_PlanoKmControlado &&
                   txtKmLivreIncluso_PlanoKmControlado == cobranca.txtKmLivreIncluso_PlanoKmControlado &&
                   txtValorPorDia_PlanoKmControlado == cobranca.txtValorPorDia_PlanoKmControlado &&
                   txtValorPorDia_PlanoKmLivre == cobranca.txtValorPorDia_PlanoKmControlado;
        }
        public PlanoDeCobranca Clonar()
        {
            return MemberwiseClone() as PlanoDeCobranca;
        }
        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(txtValorKmRodado_PlanoDiario);
            hash.Add(txtValorPorDia_PlanoDiario);
            hash.Add(txtValorKmRodado_PlanoKmControlado);
            hash.Add(txtKmLivreIncluso_PlanoKmControlado);
            hash.Add(txtValorPorDia_PlanoKmControlado);
            hash.Add(txtValorPorDia_PlanoKmLivre);
            return hash.ToHashCode();
        }
    }
}

