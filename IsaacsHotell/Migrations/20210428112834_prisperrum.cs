using Microsoft.EntityFrameworkCore.Migrations;

namespace IsaacsHotell.Migrations
{
    public partial class prisperrum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrisPerNatt",
                table: "Rum",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrisPerNatt",
                value: 399.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrisPerNatt",
                value: 399.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 3,
                column: "PrisPerNatt",
                value: 399.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 4,
                column: "PrisPerNatt",
                value: 399.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 5,
                column: "PrisPerNatt",
                value: 399.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 6,
                column: "PrisPerNatt",
                value: 499.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 7,
                column: "PrisPerNatt",
                value: 499.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 8,
                column: "PrisPerNatt",
                value: 499.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 9,
                column: "PrisPerNatt",
                value: 499.0);

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 10,
                column: "PrisPerNatt",
                value: 499.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrisPerNatt",
                table: "Rum");
        }
    }
}
