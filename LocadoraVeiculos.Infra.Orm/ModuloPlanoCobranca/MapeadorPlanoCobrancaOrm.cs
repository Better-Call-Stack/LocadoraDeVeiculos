using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.ValorKmRodado_PlanoDiario).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ValorPorDia_PlanoDiario).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ValorKmRodado_PlanoKmControlado).HasColumnType("decimal(10,2)");
            builder.Property(x => x.KmLivreIncluso_PlanoKmControlado).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ValorPorDia_PlanoKmControlado).HasColumnType("decimal(10,2)");
            builder.Property(x => x.ValorPorDia_PlanoKmLivre).HasColumnType("decimal(10,2)");
            builder.HasOne(x => x.GrupoDeVeiculos);
        }
    }
}
