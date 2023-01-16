using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class vistas_ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    id_tickect = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    plato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio_plat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.id_tickect);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
