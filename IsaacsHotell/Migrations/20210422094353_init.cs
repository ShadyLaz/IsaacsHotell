using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IsaacsHotell.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anställda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roll = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anställda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordrar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    GästId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antalsovplatser = table.Column<int>(type: "int", nullable: false),
                    Smutsigt = table.Column<bool>(type: "bit", nullable: false),
                    BokningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gäster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BokningId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gäster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gäster_Ordrar_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Ordrar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bokningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Incheckning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Utcheckning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GästId = table.Column<int>(type: "int", nullable: false),
                    RumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bokningar_Gäster_GästId",
                        column: x => x.GästId,
                        principalTable: "Gäster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bokningar_Rum_RumId",
                        column: x => x.RumId,
                        principalTable: "Rum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_GästId",
                table: "Bokningar",
                column: "GästId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningar_RumId",
                table: "Bokningar",
                column: "RumId");

            migrationBuilder.CreateIndex(
                name: "IX_Gäster_OrderId",
                table: "Gäster",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anställda");

            migrationBuilder.DropTable(
                name: "Bokningar");

            migrationBuilder.DropTable(
                name: "Gäster");

            migrationBuilder.DropTable(
                name: "Rum");

            migrationBuilder.DropTable(
                name: "Ordrar");
        }
    }
}
