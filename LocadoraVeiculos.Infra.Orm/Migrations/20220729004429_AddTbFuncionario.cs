using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AddTbFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    DataDeAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Login = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: true),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Fabricante = table.Column<string>(type: "varchar(100)", nullable: true),
                    Placa = table.Column<string>(type: "varchar(7)", nullable: true),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    StatusVeiculo = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    CapacidadeTanque = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    KmPercorrido = table.Column<int>(type: "int", nullable: false),
                    FotoVeiculo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoVeiculos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "TBGrupoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoId",
                table: "TBVeiculo",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbFuncionario");

            migrationBuilder.DropTable(
                name: "TBVeiculo");
        }
    }
}
