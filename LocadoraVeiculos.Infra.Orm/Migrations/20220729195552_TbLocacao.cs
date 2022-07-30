using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TbLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TbTaxa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataLocacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrevisaoDevolucao = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlanoSelecionado = table.Column<string>(type: "varchar(15)", nullable: true),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusLocacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TbCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TbCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TBPlanoDeCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTaxa_LocacaoId",
                table: "TbTaxa",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa",
                column: "LocacaoId",
                principalTable: "TbLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa");

            migrationBuilder.DropTable(
                name: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbTaxa_LocacaoId",
                table: "TbTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TbTaxa");
        }
    }
}
