using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class property_cat_menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "informacion_plato",
                table: "Menu_Mobile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "url_foto",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6,
                column: "estado_pedido",
                value: "Su pedido fue Cancelado");

            migrationBuilder.InsertData(
                table: "Estado_Pedido",
                columns: new[] { "id_estado_pedido", "estado_pedido" },
                values: new object[] { 10, "Finalizado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "informacion_plato",
                table: "Menu_Mobile");

            migrationBuilder.DropColumn(
                name: "url_foto",
                table: "Categoria");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6,
                column: "estado_pedido",
                value: "Finalizado");
        }
    }
}
