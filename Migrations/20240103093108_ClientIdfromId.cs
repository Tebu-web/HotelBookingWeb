using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingWeb.Migrations
{
    public partial class ClientIdfromId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Camera",
                newName: "CameraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Client",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CameraId",
                table: "Camera",
                newName: "Id");
        }
    }
}
