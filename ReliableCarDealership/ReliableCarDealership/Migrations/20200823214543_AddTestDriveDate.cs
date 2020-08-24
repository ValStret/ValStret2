using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliableCarDealership.Migrations
{
    public partial class AddTestDriveDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TestDriveDate",
                table: "TestDriveCars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDriveDate",
                table: "TestDriveCars");
        }
    }
}
