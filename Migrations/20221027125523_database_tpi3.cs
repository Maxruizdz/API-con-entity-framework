using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class database_tpi3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado_Pedido",
                columns: table => new
                {
                    id_estado_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_pedido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado_Pedido", x => x.id_estado_pedido);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Mobile",
                columns: table => new
                {
                    id_MenuMobile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    plato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_Categoria = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_foto_menu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Mobile", x => x.id_MenuMobile);
                    table.ForeignKey(
                        name: "FK_Menu_Mobile_Categoria_id_Categoria",
                        column: x => x.id_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_Busqueda",
                columns: table => new
                {
                    id_metodoBusqueda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_deBusqueda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo_Busqueda", x => x.id_metodoBusqueda);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Mobile_id_Categoria",
                table: "Menu_Mobile",
                column: "id_Categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado_Pedido");

            migrationBuilder.DropTable(
                name: "Menu_Mobile");

            migrationBuilder.DropTable(
                name: "Metodo_Busqueda");
        }
    }
}
