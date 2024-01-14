using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GourmandGurus.Migrations
{
    public partial class Vegetarian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vegetarian",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vegetarian",
                table: "Recipe");
        }
    }
}
