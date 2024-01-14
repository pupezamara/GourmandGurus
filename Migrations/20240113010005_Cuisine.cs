using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GourmandGurus.Migrations
{
    public partial class Cuisine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuisineID",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CuisineID",
                table: "Recipe",
                column: "CuisineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Cuisine_CuisineID",
                table: "Recipe",
                column: "CuisineID",
                principalTable: "Cuisine",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Cuisine_CuisineID",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_CuisineID",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "CuisineID",
                table: "Recipe");
        }
    }
}
