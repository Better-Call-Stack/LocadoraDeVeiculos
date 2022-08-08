﻿// <auto-generated />
using System;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDeVeiculosDbContext))]
    [Migration("20220808012444_tbVeiculoCorrecoes")]
    partial class tbVeiculoCorrecoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TbCliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ValidadeCNH")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TbCondutor");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("date");

                    b.Property<Guid>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quilometragem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorCombustivel")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("VolumeTanque")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TBDevolucao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DataDeAdmissao")
                        .HasColumnType("date");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TbFuncionario");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoDeVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("datetime");

                    b.Property<Guid>("PlanoDeCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlanoSelecionado")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("PrevisaoDevolucao")
                        .HasColumnType("datetime");

                    b.Property<int>("StatusLocacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("PlanoDeCobrancaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TbLocacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoDeVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("KmLivreIncluso_PlanoKmControlado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorKmRodado_PlanoDiario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorKmRodado_PlanoKmControlado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorPorDia_PlanoDiario")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorPorDia_PlanoKmControlado")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorPorDia_PlanoKmLivre")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoDeVeiculosId");

                    b.ToTable("TBPlanoDeCobranca");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DevolucaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DevolucaoId");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TbTaxa");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<decimal>("CapacidadeTanque")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Cor")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Fabricante")
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("FotoVeiculo")
                        .HasColumnType("varbinary(MAX)");

                    b.Property<Guid?>("GrupoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KmPercorrido")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .HasColumnType("varchar(7)");

                    b.Property<int>("StatusVeiculo")
                        .HasColumnType("int");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("TBVeiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", "Locacao")
                        .WithMany()
                        .HasForeignKey("LocacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locacao");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoDeCobranca", "PlanoDeCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoDeCobrancaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("PlanoDeCobranca");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoDeCobranca", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoDeVeiculos", "GrupoDeVeiculos")
                        .WithMany()
                        .HasForeignKey("GrupoDeVeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoDeVeiculos");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxa.Taxa", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("DevolucaoId");

                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("LocacaoId");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos.GrupoDeVeiculos", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloDevolucao.Devolucao", b =>
                {
                    b.Navigation("Taxas");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Navigation("Taxas");
                });
#pragma warning restore 612, 618
        }
    }
}
