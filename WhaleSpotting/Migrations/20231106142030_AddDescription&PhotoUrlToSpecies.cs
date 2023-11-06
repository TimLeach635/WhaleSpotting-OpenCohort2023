using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhaleSpotting.Migrations
{
    public partial class AddDescriptionPhotoUrlToSpecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Species",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Species",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Species");
        }
    }
}
