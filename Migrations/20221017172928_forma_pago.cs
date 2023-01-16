using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class forma_pago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Metodo_Pago",
                columns: new[] { "id_MetodoPago", "tipo_pago" },
                values: new object[] { 4, "Plataforma Digital" });

            migrationBuilder.InsertData(
                table: "Metodo_Pago",
                columns: new[] { "id_MetodoPago", "tipo_pago" },
                values: new object[] { 5, "No se realizo el pago" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Metodo_Pago",
                keyColumn: "id_MetodoPago",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Metodo_Pago",
                keyColumn: "id_MetodoPago",
                keyValue: 5);
        }
    }
}
