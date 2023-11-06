using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class imageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "imageurl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageurl",
                table: "Cars");

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
    }
}
