using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimallAPI_rest.Migrations
{
    public partial class cambios_claves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ Factura _Pedido_id_pedido",
                table: " Factura ");

            migrationBuilder.DropColumn(
                name: "id_fact",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "id_pedido",
                table: " Factura ",
                newName: "pedidoID");

            migrationBuilder.RenameIndex(
                name: "IX_ Factura _id_pedido",
                table: " Factura ",
                newName: "IX_ Factura _pedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ Factura _Pedido_pedidoID",
                table: " Factura ",
                column: "pedidoID",
                principalTable: "Pedido",
                principalColumn: "id_Pedido",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ Factura _Pedido_pedidoID",
                table: " Factura ");

            migrationBuilder.RenameColumn(
                name: "pedidoID",
                table: " Factura ",
                newName: "id_pedido");

            migrationBuilder.RenameIndex(
                name: "IX_ Factura _pedidoID",
                table: " Factura ",
                newName: "IX_ Factura _id_pedido");

            migrationBuilder.AddColumn<Guid>(
                name: "id_fact",
                table: "Pedido",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_ Factura _Pedido_id_pedido",
                table: " Factura ",
                column: "id_pedido",
                principalTable: "Pedido",
                principalColumn: "id_Pedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
