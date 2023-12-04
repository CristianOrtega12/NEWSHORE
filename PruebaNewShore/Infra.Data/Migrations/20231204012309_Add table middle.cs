using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class Addtablemiddle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JourneyFlight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightsId = table.Column<int>(nullable: false),
                    JourneyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyFlight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JourneyFlight_Fligth_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Fligth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyFlight_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JourneyFlight_FlightsId",
                table: "JourneyFlight",
                column: "FlightsId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyFlight_JourneyId",
                table: "JourneyFlight",
                column: "JourneyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JourneyFlight");
        }
    }
}
