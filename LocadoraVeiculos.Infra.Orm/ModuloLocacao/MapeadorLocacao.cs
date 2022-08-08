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
            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(x => x.Condutor).WithMany().HasForeignKey(x => x.CondutorId).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(x => x.PlanoDeCobranca).WithMany().HasForeignKey(x => x.PlanoDeCobrancaId).OnDelete(DeleteBehavior.NoAction); 
            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).OnDelete(DeleteBehavior.NoAction); ;
            builder.HasMany(x => x.Taxas).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.PlanoSelecionado).HasColumnType("varchar(15)");
            builder.Property(x => x.DataLocacao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.PrevisaoDevolucao).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ValorDiario).HasColumnType("decimal(18,2)");
            builder.Property(x => x.StatusLocacao).HasConversion<int>();


        }
    }
}
