using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Final.Migrations
{
    public partial class addingExtraTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    travellerId = table.Column<int>(type: "int", nullable: false),
                    cityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityPopulation = table.Column<int>(type: "int", nullable: false),
                    cityAttraction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityId);
                    table.ForeignKey(
                        name: "FK_cities_traveller_travellerId",
                        column: x => x.travellerId,
                        principalTable: "traveller",
                        principalColumn: "travellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spots",
                columns: table => new
                {
                    spotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    travellerId = table.Column<int>(type: "int", nullable: false),
                    spotName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spotLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spotDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spots", x => x.spotId);
                    table.ForeignKey(
                        name: "FK_spots_traveller_travellerId",
                        column: x => x.travellerId,
                        principalTable: "traveller",
                        principalColumn: "travellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_travellerId",
                table: "cities",
                column: "travellerId");

            migrationBuilder.CreateIndex(
                name: "IX_spots_travellerId",
                table: "spots",
                column: "travellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "spots");
        }
    }
}
