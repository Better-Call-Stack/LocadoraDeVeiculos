using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class Taxas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa",
                column: "LocacaoId",
                principalTable: "TbLocacao",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa");

            migrationBuilder.AddForeignKey(
                name: "FK_TbTaxa_TbLocacao_LocacaoId",
                table: "TbTaxa",
                column: "LocacaoId",
                principalTable: "TbLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
