using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class datain_es : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estado_Pedido",
                columns: new[] { "id_estado_pedido", "estado_pedido" },
                values: new object[,]
                {
                    { 1, "En espera" },
                    { 2, "Su pedido fue tomado" },
                    { 3, "Su pedido esta siendo pregarado" },
                    { 4, "su pedido esta listo para retirarlo" },
                    { 5, "Su pedido fue enviado" },
                    { 6, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Metodo_Busqueda",
                columns: new[] { "id_metodoBusqueda", "tipo_deBusqueda" },
                values: new object[,]
                {
                    { 1, "Buscar por el restaurante" },
                    { 2, "Delivery" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 2);
        }
    }
}
