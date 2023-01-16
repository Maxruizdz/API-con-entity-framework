using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class data_metodos_busqueda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 1,
                column: "tipo_deBusqueda",
                value: "Delivery");

            migrationBuilder.UpdateData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 2,
                column: "tipo_deBusqueda",
                value: "Retirar por el local");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 1,
                column: "tipo_deBusqueda",
                value: "Buscar por el restaurante");

            migrationBuilder.UpdateData(
                table: "Metodo_Busqueda",
                keyColumn: "id_metodoBusqueda",
                keyValue: 2,
                column: "tipo_deBusqueda",
                value: "Delivery");
        }
    }
}
