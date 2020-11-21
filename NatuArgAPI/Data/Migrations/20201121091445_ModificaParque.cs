using Microsoft.EntityFrameworkCore.Migrations;

namespace NatuArgAPI.Migrations
{
    public partial class ModificaParque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Parques",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Parques",
                newName: "Descripcio");
        }
    }
}
