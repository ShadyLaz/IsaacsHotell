using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsaacsHotell.Migrations
{
    public partial class listabokning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Gäster_GästId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Rum_RumId",
                table: "Bokningar");

            migrationBuilder.InsertData(
                table: "Anställda",
                columns: new[] { "Id", "Efternamn", "Förnamn", "Roll" },
                values: new object[,]
                {
                    { 1, "Anka", "Anders", "Admin" },
                    { 2, "Bengtsson", "Bertil", "Receptionist" },
                    { 3, "Cello", "Ceasar", "Städare" }
                });

            migrationBuilder.InsertData(
                table: "Ordrar",
                columns: new[] { "Id", "GästId", "Pris" },
                values: new object[] { 1, 1, 990.0 });

            migrationBuilder.InsertData(
                table: "Rum",
                columns: new[] { "Id", "Antalsovplatser", "BokningId", "Namn", "Smutsigt" },
                values: new object[] { 1, 2, 1, "Jan", false });

            migrationBuilder.InsertData(
                table: "Gäster",
                columns: new[] { "Id", "BokningId", "Efternamn", "Förnamn", "OrderId" },
                values: new object[] { 1, 1, "Aronsson", "Alf", 1 });

            migrationBuilder.InsertData(
                table: "Bokningar",
                columns: new[] { "Id", "GästId", "Incheckning", "RumId", "Utcheckning" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Gäster_GästId",
                table: "Bokningar",
                column: "GästId",
                principalTable: "Gäster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Rum_RumId",
                table: "Bokningar",
                column: "RumId",
                principalTable: "Rum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Gäster_GästId",
                table: "Bokningar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokningar_Rum_RumId",
                table: "Bokningar");

            migrationBuilder.DeleteData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Anställda",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bokningar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gäster",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rum",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ordrar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Gäster_GästId",
                table: "Bokningar",
                column: "GästId",
                principalTable: "Gäster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokningar_Rum_RumId",
                table: "Bokningar",
                column: "RumId",
                principalTable: "Rum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
