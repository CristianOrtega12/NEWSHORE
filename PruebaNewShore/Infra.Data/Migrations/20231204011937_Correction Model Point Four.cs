using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class CorrectionModelPointFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fligth_Journey_JourneyId",
                table: "Fligth");

            migrationBuilder.DropForeignKey(
                name: "FK_Fligth_Transport_TransportId",
                table: "Fligth");

            migrationBuilder.DropIndex(
                name: "IX_Fligth_JourneyId",
                table: "Fligth");

            migrationBuilder.DropColumn(
                name: "JourneyId",
                table: "Fligth");

            migrationBuilder.AlterColumn<int>(
                name: "TransportId",
                table: "Fligth",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fligth_Transport_TransportId",
                table: "Fligth",
                column: "TransportId",
                principalTable: "Transport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fligth_Transport_TransportId",
                table: "Fligth");

            migrationBuilder.AlterColumn<int>(
                name: "TransportId",
                table: "Fligth",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "JourneyId",
                table: "Fligth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fligth_JourneyId",
                table: "Fligth",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fligth_Journey_JourneyId",
                table: "Fligth",
                column: "JourneyId",
                principalTable: "Journey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fligth_Transport_TransportId",
                table: "Fligth",
                column: "TransportId",
                principalTable: "Transport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
