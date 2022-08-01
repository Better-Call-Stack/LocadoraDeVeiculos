using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class MapeadorDevolucaoOrm : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TBDevolucao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.ValorGasolina).HasColumnType("decimal(10,2)");
            builder.Property(x => x.Valor).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Quilometragem).HasColumnType("decimal(18,2)");
            builder.Property(x => x.DataDevolucao).HasColumnType("date");
            builder.Property(x => x.VolumeTanque).HasColumnType("varchar(10)");
            builder.HasOne(x => x.Locacao);
            builder.HasMany(x => x.Taxas);
        }
    }
}
