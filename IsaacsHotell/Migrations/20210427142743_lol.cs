using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsaacsHotell.Migrations
{
    public partial class lol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roll",
                table: "Anställda");

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Antalsovplatser", "BokningId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Rum",
                columns: new[] { "Id", "Antalsovplatser", "BokningId", "Namn", "Smutsigt" },
                values: new object[,]
                {
                    { 2, 1, null, "Feb", false },
                    { 3, 1, null, "Mar", false },
                    { 4, 1, null, "Apr", false },
                    { 5, 1, null, "Maj", false },
                    { 6, 2, null, "Jun", false },
                    { 7, 2, null, "Jul", false },
                    { 8, 2, null, "Aug", false },
                    { 9, 2, null, "Sep", false },
                    { 10, 2, null, "Okt", false }
                });

            migrationBuilder.InsertData(
                table: "Bokningar",
                columns: new[] { "Id", "GästId", "Incheckning", "RumId", "Utcheckning" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "Roll",
                table: "Anställda",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 1,
                column: "Roll",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 2,
                column: "Roll",
                value: "Receptionist");

            migrationBuilder.UpdateData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 3,
                column: "Roll",
                value: "Städare");

            migrationBuilder.UpdateData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Antalsovplatser", "BokningId" },
                values: new object[] { 2, 1 });
        }
    }
}
