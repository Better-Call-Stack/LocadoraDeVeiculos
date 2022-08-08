using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class tbVeiculoCorrecoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusVeiculo",
                table: "TBVeiculo",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoVeiculo",
                table: "TBVeiculo",
                type: "varbinary(MAX)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "StatusVeiculo",
                table: "TBVeiculo",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FotoVeiculo",
                table: "TBVeiculo",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)",
                oldNullable: true);
        }
    }
}
