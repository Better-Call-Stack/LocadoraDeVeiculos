﻿using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {

            builder.ToTable("TbFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.CPF).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("varchar(50)");
            builder.Property(x => x.Salario).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.DataDeAdmissao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Login).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(100)");
            builder.Property(x => x.Perfil).HasColumnType("int").IsRequired();

        }
    }
}
