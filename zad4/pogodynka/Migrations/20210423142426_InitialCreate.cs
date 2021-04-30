using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pogodynka.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tytuł = table.Column<string>(type: "TEXT", nullable: true),
                    DataWydania = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gatunek = table.Column<string>(type: "TEXT", nullable: true),
                    Platforma = table.Column<string>(type: "TEXT", nullable: true),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
