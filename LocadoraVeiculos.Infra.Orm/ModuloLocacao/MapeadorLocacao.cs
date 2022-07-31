using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacao : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TbLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Cliente).WithOne().IsRequired();
            builder.HasOne(x => x.Condutor).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PlanoDeCobranca).WithOne().IsRequired();
            builder.HasOne(x => x.Veiculo).WithOne().IsRequired();
            builder.HasMany(x => x.Taxas);
            builder.Property(x => x.PlanoSelecionado).HasColumnType("varchar(15)");
            builder.Property(x => x.DataLocacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.PrevisaoDevolucao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.StatusLocacao).HasConversion<int>();


        }
    }
}
