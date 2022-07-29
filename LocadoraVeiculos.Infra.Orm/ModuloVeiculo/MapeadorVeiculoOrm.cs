using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    internal class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)");
            builder.Property(x => x.Fabricante).HasColumnType("varchar(100)");
            builder.Property(x => x.Placa).HasColumnType("varchar(7)");
            builder.Property(x => x.Cor).HasColumnType("varchar(100)");
            builder.Property(x => x.TipoCombustivel).HasColumnType("int");
            builder.Property(x => x.KmPercorrido).HasColumnType("int");
            builder.Property(x => x.StatusVeiculo).HasColumnType("int");
            builder.Property(x => x.StatusVeiculo).HasColumnType("varbinary(MAX)");
            builder.HasOne(x => x.Grupo);
        }
    }
}
