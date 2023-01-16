using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class property_cat_menu20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6,
                column: "estado_pedido",
                value: "Finalizado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 10,
                column: "estado_pedido",
                value: "Su pedido fue Cancelado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6,
                column: "estado_pedido",
                value: "Su pedido fue Cancelado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 10,
                column: "estado_pedido",
                value: "Finalizado");
        }
    }
}
