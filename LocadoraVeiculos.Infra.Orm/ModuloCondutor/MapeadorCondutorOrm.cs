using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TbCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.CPF).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.CNH).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ValidadeCNH).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("varchar(100)");

            builder.HasOne(x => x.Cliente);
        }
    }
}
