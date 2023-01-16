using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class database_tpi3_parte2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido_Mobile",
                columns: table => new
                {
                    Id_PedidoMobile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_metodo_pago = table.Column<int>(type: "int", nullable: false),
                    id_metodo_busqueda = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_estado_pedido = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Mobile", x => x.Id_PedidoMobile);
                    table.ForeignKey(
                        name: "FK_Pedido_Mobile_Estado_Pedido_id_estado_pedido",
                        column: x => x.id_estado_pedido,
                        principalTable: "Estado_Pedido",
                        principalColumn: "id_estado_pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Mobile_Metodo_Busqueda_id_metodo_busqueda",
                        column: x => x.id_metodo_busqueda,
                        principalTable: "Metodo_Busqueda",
                        principalColumn: "id_metodoBusqueda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Mobile_Metodo_Pago_id_metodo_pago",
                        column: x => x.id_metodo_pago,
                        principalTable: "Metodo_Pago",
                        principalColumn: "id_MetodoPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Mobile_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Pedido_Mobiles",
                columns: table => new
                {
                    id_pedido_menu_mobile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_pedido_mobile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_menuMobile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Pedido_Mobiles", x => x.id_pedido_menu_mobile);
                    table.ForeignKey(
                        name: "FK_Menu_Pedido_Mobiles_Menu_Mobile_id_menuMobile",
                        column: x => x.id_menuMobile,
                        principalTable: "Menu_Mobile",
                        principalColumn: "id_MenuMobile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Pedido_Mobiles_Pedido_Mobile_id_pedido_mobile",
                        column: x => x.id_pedido_mobile,
                        principalTable: "Pedido_Mobile",
                        principalColumn: "Id_PedidoMobile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Pedido_Mobiles_id_menuMobile",
                table: "Menu_Pedido_Mobiles",
                column: "id_menuMobile");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Pedido_Mobiles_id_pedido_mobile",
                table: "Menu_Pedido_Mobiles",
                column: "id_pedido_mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Mobile_id_estado_pedido",
                table: "Pedido_Mobile",
                column: "id_estado_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Mobile_id_metodo_busqueda",
                table: "Pedido_Mobile",
                column: "id_metodo_busqueda");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Mobile_id_metodo_pago",
                table: "Pedido_Mobile",
                column: "id_metodo_pago");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Mobile_id_usuario",
                table: "Pedido_Mobile",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu_Pedido_Mobiles");

            migrationBuilder.DropTable(
                name: "Pedido_Mobile");
        }
    }
}
