using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NatuArgAPI.Migrations
{
    public partial class AgregaAtracciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atracciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParqueId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atracciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atracciones_Parques_ParqueId",
                        column: x => x.ParqueId,
                        principalTable: "Parques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atracciones_ParqueId",
                table: "Atracciones",
                column: "ParqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atracciones");
        }
    }
}
