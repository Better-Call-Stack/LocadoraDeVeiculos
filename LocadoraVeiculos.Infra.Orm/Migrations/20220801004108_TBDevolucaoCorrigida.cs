using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TBDevolucaoCorrigida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBDevolucao_TbTaxa_TaxaId",
                table: "TBDevolucao");

            migrationBuilder.DropIndex(
                name: "IX_TBDevolucao_TaxaId",
                table: "TBDevolucao");

            migrationBuilder.DropColumn(
                name: "TaxaId",
                table: "TBDevolucao");

            migrationBuilder.AddColumn<Guid>(
                name: "DevolucaoId",
                table: "TbTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VolumeTanque",
                table: "TBDevolucao",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TbTaxa_DevolucaoId",
                table: "TbTaxa",
                column: "DevolucaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxa_TBDevolucao_DevolucaoId",
                table: "TbTaxa",
                column: "DevolucaoId",
                principalTable: "TBDevolucao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxa_TBDevolucao_DevolucaoId",
                table: "TbTaxa");

            migrationBuilder.DropIndex(
                name: "IX_TbTaxa_DevolucaoId",
                table: "TbTaxa");

            migrationBuilder.DropColumn(
                name: "DevolucaoId",
                table: "TbTaxa");

            migrationBuilder.AlterColumn<int>(
                name: "VolumeTanque",
                table: "TBDevolucao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxaId",
                table: "TBDevolucao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TBDevolucao_TaxaId",
                table: "TBDevolucao",
                column: "TaxaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBDevolucao_TbTaxa_TaxaId",
                table: "TBDevolucao",
                column: "TaxaId",
                principalTable: "TbTaxa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
