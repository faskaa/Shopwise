using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndProject.Migrations
{
    public partial class CapacityResistanceColorAndMaterialColumnAddedToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WaterResistance",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WaterResistance",
                table: "Products");
        }
    }
}
