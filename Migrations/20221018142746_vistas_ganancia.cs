using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class vistas_ganancia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ganancia_metodo",
                columns: table => new
                {
                    id_ganacia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    met_pagado = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganancia_metodo", x => x.id_ganacia);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ganancia_metodo");
        }
    }
}
