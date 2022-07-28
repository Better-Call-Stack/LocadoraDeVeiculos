using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TBPlanoDeCobrancaColunasDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoDeVeiculosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorKmRodado_PlanoDiario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorPorDia_PlanoDiario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorKmRodado_PlanoKmControlado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    KmLivreIncluso_PlanoKmControlado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorPorDia_PlanoKmControlado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorPorDia_PlanoKmLivre = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_TBGrupoVeiculos_GrupoDeVeiculosId",
                        column: x => x.GrupoDeVeiculosId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_GrupoDeVeiculosId",
                table: "TBPlanoDeCobranca",
                column: "GrupoDeVeiculosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");

            migrationBuilder.DropTable(
                name: "TBGrupoVeiculos");
        }
    }
}
