using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class ProblemaComPlanoEmLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId",
                principalTable: "TBPlanoDeCobranca",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                table: "TbLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_TbLocacao_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbLocacao_TBPlanoDeCobranca_PlanoDeCobrancaId",
                table: "TbLocacao",
                column: "PlanoDeCobrancaId",
                principalTable: "TBPlanoDeCobranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
