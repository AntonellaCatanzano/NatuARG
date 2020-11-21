using Microsoft.EntityFrameworkCore.Migrations;

namespace NatuArgAPI.Migrations
{
    public partial class asdasdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagen1",
                table: "Atracciones",
                newName: "Imagen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Atracciones",
                newName: "Imagen1");
        }
    }
}
