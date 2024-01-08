﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asztalfoglalas.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asztal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Megnevezes = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ferohely = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asztal", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foglalas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefonszam = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Letszam = table.Column<int>(type: "int", nullable: false),
                    AsztalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foglalas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foglalas_Asztal_AsztalID",
                        column: x => x.AsztalID,
                        principalTable: "Asztal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Asztal",
                columns: new[] { "Id", "Ferohely", "Megnevezes" },
                values: new object[,]
                {
                    { 1, 6, "1-es asztal" },
                    { 2, 3, "2-es asztal" },
                    { 3, 4, "3-es asztal" },
                    { 4, 5, "4-es asztal" },
                    { 5, 8, "5-es asztal" }
                });

            migrationBuilder.InsertData(
                table: "Foglalas",
                columns: new[] { "ID", "AsztalID", "Datum", "Letszam", "Nev", "Telefonszam" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Soós Gábor", "06201231234" },
                    { 2, 3, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nits László", "06201231230" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foglalas_AsztalID",
                table: "Foglalas",
                column: "AsztalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foglalas");

            migrationBuilder.DropTable(
                name: "Asztal");
        }
    }
}
