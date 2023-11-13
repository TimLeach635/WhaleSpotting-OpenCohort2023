using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhaleSpotting.Migrations
{
    public partial class AddSpeciesIdToSightings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "Sightings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_SpeciesId",
                table: "Sightings",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sightings_Species_SpeciesId",
                table: "Sightings",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sightings_Species_SpeciesId",
                table: "Sightings");

            migrationBuilder.DropIndex(
                name: "IX_Sightings_SpeciesId",
                table: "Sightings");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Sightings");
        }
    }
}
