using Microsoft.EntityFrameworkCore.Migrations;

namespace ReliableCarDealership.Migrations
{
    public partial class Parts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PartMakeModel = table.Column<string>(nullable: false),
                    PartVehicleYear = table.Column<int>(nullable: false),
                    PartPrice = table.Column<double>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PartImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Part");
        }
    }
}
