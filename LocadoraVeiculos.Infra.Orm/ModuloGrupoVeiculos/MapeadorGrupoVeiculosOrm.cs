using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculosOrm : IEntityTypeConfiguration<GrupoDeVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoDeVeiculos> builder)
        {
            builder.ToTable("TBGrupoVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
