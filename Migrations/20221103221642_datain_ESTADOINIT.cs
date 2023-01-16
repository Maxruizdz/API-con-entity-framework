using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class datain_ESTADOINIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 1,
                column: "estado_pedido",
                value: "Por confirmar");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 2,
                column: "estado_pedido",
                value: "Pedido confirmado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 3,
                column: "estado_pedido",
                value: "En preparacion");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 4,
                column: "estado_pedido",
                value: "En camino");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 5,
                column: "estado_pedido",
                value: "Listo para retirar");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 6,
                column: "estado_pedido",
                value: "Entregado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 10,
                column: "estado_pedido",
                value: "Cancelado");

            migrationBuilder.InsertData(
                table: "Estado_Pedido",
                columns: new[] { "id_estado_pedido", "estado_pedido" },
                values: new object[] { 7, "Retirado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 1,
                column: "estado_pedido",
                value: "En espera");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 2,
                column: "estado_pedido",
                value: "Su pedido fue tomado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 3,
                column: "estado_pedido",
                value: "Su pedido esta siendo pregarado");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 4,
                column: "estado_pedido",
                value: "su pedido esta listo para retirarlo");

            migrationBuilder.UpdateData(
                table: "Estado_Pedido",
                keyColumn: "id_estado_pedido",
                keyValue: 5,
                column: "estado_pedido",
                value: "Su pedido fue enviado");

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
    }
}
