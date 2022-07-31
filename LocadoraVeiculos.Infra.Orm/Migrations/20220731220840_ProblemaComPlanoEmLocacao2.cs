using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class ProblemaComPlanoEmLocacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TbCliente_ClienteId",
                table: "TbLocacao");

            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TbCliente_ClienteId",
                table: "TbLocacao",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId",
                principalTable: "TBVeiculo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TbCliente_ClienteId",
                table: "TbLocacao");

            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_ClienteId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_CondutorId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao");

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
                name: "IX_TbLocacao_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TbCliente_ClienteId",
                table: "TbLocacao",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TBVeiculo_VeiculoId",
                table: "TbLocacao",
                column: "VeiculoId",
                principalTable: "TBVeiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
