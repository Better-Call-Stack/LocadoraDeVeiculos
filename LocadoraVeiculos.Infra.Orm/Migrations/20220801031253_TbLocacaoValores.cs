using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class TbLocacaoValores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "TbLocacao",
                newName: "ValorDiario");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "TbLocacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "TbLocacao");

            migrationBuilder.RenameColumn(
                name: "ValorDiario",
                table: "TbLocacao",
                newName: "Valor");
        }
    }
}
