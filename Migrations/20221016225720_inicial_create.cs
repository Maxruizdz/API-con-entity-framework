using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class inicial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_cliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    id_empleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rol = table.Column<int>(type: "int", nullable: false),
                    email_empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nickname_empleado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.id_empleado);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    id_mesa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numero_mesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.id_mesa);
                });

            migrationBuilder.CreateTable(
                name: "Metodo_Pago",
                columns: table => new
                {
                    id_MetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_pago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo_Pago", x => x.id_MetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id_menu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    comida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idcategoria = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id_menu);
                    table.ForeignKey(
                        name: "FK_Menu_Categoria_idcategoria",
                        column: x => x.idcategoria,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id_Pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_mesaa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_dni_cliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_fact = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    metodo_pago_pedido = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora_pedido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id_Pedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_id_dni_cliente",
                        column: x => x.id_dni_cliente,
                        principalTable: "Cliente",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Mesa_id_mesaa",
                        column: x => x.id_mesaa,
                        principalTable: "Mesa",
                        principalColumn: "id_mesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Metodo_Pago_metodo_pago_pedido",
                        column: x => x.metodo_pago_pedido,
                        principalTable: "Metodo_Pago",
                        principalColumn: "id_MetodoPago");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id_reservar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    confirmo_reserva = table.Column<bool>(type: "bit", nullable: false),
                    id_MESA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha_de_reseva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora_reserva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad_personas = table.Column<int>(type: "int", nullable: false),
                    reservado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id_reservar);
                    table.ForeignKey(
                        name: "FK_Reservas_Mesa_id_MESA",
                        column: x => x.id_MESA,
                        principalTable: "Mesa",
                        principalColumn: "id_mesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_usuario_ID_usuario",
                        column: x => x.ID_usuario,
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: " Factura ",
                columns: table => new
                {
                    id_factura = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_pedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ Factura ", x => x.id_factura);
                    table.ForeignKey(
                        name: "FK_ Factura _Pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Pedido",
                        principalColumn: "id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Menu",
                columns: table => new
                {
                    ID_PEDIDO_MENU = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedido_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_MENU = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Menu", x => x.ID_PEDIDO_MENU);
                    table.ForeignKey(
                        name: "FK_Pedido_Menu_Menu_ID_MENU",
                        column: x => x.ID_MENU,
                        principalTable: "Menu",
                        principalColumn: "id_menu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Menu_Pedido_pedido_ID",
                        column: x => x.pedido_ID,
                        principalTable: "Pedido",
                        principalColumn: "id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "tipo_categoria" },
                values: new object[,]
                {
                    { 1, "Cafe" },
                    { 2, "Te" },
                    { 3, "Platos Principales" },
                    { 4, "Factura" },
                    { 5, "Entradas" },
                    { 6, "Postres" }
                });

            migrationBuilder.InsertData(
                table: "Mesa",
                columns: new[] { "id_mesa", "numero_mesa" },
                values: new object[,]
                {
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"), 2 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb403"), 3 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb404"), 4 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb405"), 5 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb406"), 6 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb407"), 7 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb408"), 8 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb409"), 9 },
                    { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Metodo_Pago",
                columns: new[] { "id_MetodoPago", "tipo_pago" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de Credito" },
                    { 3, "Tarjeta de Debito" }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "id_menu", "comida", "idcategoria", "precio" },
                values: new object[] { new Guid("0f860902-f798-4c59-a513-1ebd0b39bbe8"), "Medialunas", 1, 100.0 });

            migrationBuilder.CreateIndex(
                name: "IX_ Factura _id_pedido",
                table: " Factura ",
                column: "id_pedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_idcategoria",
                table: "Menu",
                column: "idcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_id_dni_cliente",
                table: "Pedido",
                column: "id_dni_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_id_mesaa",
                table: "Pedido",
                column: "id_mesaa");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_metodo_pago_pedido",
                table: "Pedido",
                column: "metodo_pago_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Menu_ID_MENU",
                table: "Pedido_Menu",
                column: "ID_MENU");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Menu_pedido_ID",
                table: "Pedido_Menu",
                column: "pedido_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_id_MESA",
                table: "Reservas",
                column: "id_MESA");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ID_usuario",
                table: "Reservas",
                column: "ID_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " Factura ");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Pedido_Menu");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Metodo_Pago");
        }
    }
}
