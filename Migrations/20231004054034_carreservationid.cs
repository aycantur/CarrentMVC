using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class carreservationid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarReservationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CarReservationId",
                table: "Users",
                column: "CarReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CarReservation_CarReservationId",
                table: "Users",
                column: "CarReservationId",
                principalTable: "CarReservation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CarReservation_CarReservationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CarReservationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarReservationId",
                table: "Users");
        }
    }
}
