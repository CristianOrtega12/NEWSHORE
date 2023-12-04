using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class AddtablemiddleJourneyFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyFlight_Fligth_FlightsId",
                table: "JourneyFlight");

            migrationBuilder.DropIndex(
                name: "IX_JourneyFlight_FlightsId",
                table: "JourneyFlight");

            migrationBuilder.DropColumn(
                name: "FlightsId",
                table: "JourneyFlight");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "JourneyFlight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JourneyFlight_FlightId",
                table: "JourneyFlight",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyFlight_Fligth_FlightId",
                table: "JourneyFlight",
                column: "FlightId",
                principalTable: "Fligth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyFlight_Fligth_FlightId",
                table: "JourneyFlight");

            migrationBuilder.DropIndex(
                name: "IX_JourneyFlight_FlightId",
                table: "JourneyFlight");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "JourneyFlight");

            migrationBuilder.AddColumn<int>(
                name: "FlightsId",
                table: "JourneyFlight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JourneyFlight_FlightsId",
                table: "JourneyFlight",
                column: "FlightsId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyFlight_Fligth_FlightsId",
                table: "JourneyFlight",
                column: "FlightsId",
                principalTable: "Fligth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
