using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class property_pedido_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_fac",
                table: "Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id_fac",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
