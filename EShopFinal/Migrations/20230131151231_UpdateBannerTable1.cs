using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopFinal.Migrations
{
    public partial class UpdateBannerTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Banner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Banner");
        }
    }
}
