using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBookingWeb.Migrations
{
    public partial class FacilitatiCamera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilitate",
                columns: table => new
                {
                    FacilitateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitate", x => x.FacilitateId);
                });

            migrationBuilder.CreateTable(
                name: "CameraFacilitate",
                columns: table => new
                {
                    CameraId = table.Column<int>(type: "int", nullable: false),
                    FacilitateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraFacilitate", x => new { x.CameraId, x.FacilitateId });
                    table.ForeignKey(
                        name: "FK_CameraFacilitate_Camera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Camera",
                        principalColumn: "CameraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CameraFacilitate_Facilitate_FacilitateId",
                        column: x => x.FacilitateId,
                        principalTable: "Facilitate",
                        principalColumn: "FacilitateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CameraFacilitate_FacilitateId",
                table: "CameraFacilitate",
                column: "FacilitateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraFacilitate");

            migrationBuilder.DropTable(
                name: "Facilitate");
        }
    }
}
