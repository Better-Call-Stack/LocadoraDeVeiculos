using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class ValorCombustivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorGasolina",
                table: "TBDevolucao",
                newName: "ValorCombustivel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorCombustivel",
                table: "TBDevolucao",
                newName: "ValorGasolina");
        }
    }
}
