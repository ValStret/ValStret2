using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliableCarDealership.Migrations
{
    public partial class AddTestDrive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestDrives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    BookedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestDriveCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(nullable: false),
                    TestDriveId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDriveCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDriveCars_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestDriveCars_TestDrives_TestDriveId",
                        column: x => x.TestDriveId,
                        principalTable: "TestDrives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveCars_CarId",
                table: "TestDriveCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDriveCars_TestDriveId",
                table: "TestDriveCars",
                column: "TestDriveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestDriveCars");

            migrationBuilder.DropTable(
                name: "TestDrives");
        }
    }
}
