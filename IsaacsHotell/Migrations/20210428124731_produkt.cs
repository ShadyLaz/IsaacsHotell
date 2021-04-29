using Microsoft.EntityFrameworkCore.Migrations;

namespace IsaacsHotell.Migrations
{
    public partial class produkt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Produkt",
                table: "Ordrar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ordrar",
                keyColumn: "Id",
                keyValue: 1,
                column: "Produkt",
                value: "Hotellnätter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Produkt",
                table: "Ordrar");
        }
    }
}
