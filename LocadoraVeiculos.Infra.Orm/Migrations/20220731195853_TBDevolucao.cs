using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TBDevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao");

            migrationBuilder.CreateTable(
                name: "TBDevolucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorGasolina = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "date", nullable: false),
                    VolumeTanque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDevolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDevolucao_TbLocacao_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "TbLocacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBDevolucao_TbTaxa_TaxaId",
                        column: x => x.TaxaId,
                        principalTable: "TbTaxa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_LocacaoId",
                table: "TBDevolucao",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_TaxaId",
                table: "TBDevolucao",
                column: "TaxaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBDevolucao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId",
                unique: true);
        }
    }
}
