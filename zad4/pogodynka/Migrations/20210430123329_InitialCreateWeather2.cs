using Microsoft.EntityFrameworkCore.Migrations;

namespace pogodynka.Migrations
{
    public partial class InitialCreateWeather2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    weatherDescription = table.Column<string>(type: "TEXT", nullable: true),
                    mainWeatherTemp = table.Column<float>(type: "REAL", nullable: false),
                    visibility = table.Column<float>(type: "REAL", nullable: false),
                    dt = table.Column<int>(type: "INTEGER", nullable: false),
                    timezone = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    cod = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
