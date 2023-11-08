using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhaleSpotting.Migrations
{
    public partial class AddUserTableAndLinkToSightings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Sightings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WsUsers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_UserId",
                table: "Sightings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WsUsers_IdentityUserId",
                table: "WsUsers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sightings_WsUsers_UserId",
                table: "Sightings",
                column: "UserId",
                principalTable: "WsUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sightings_WsUsers_UserId",
                table: "Sightings");

            migrationBuilder.DropTable(
                name: "WsUsers");

            migrationBuilder.DropIndex(
                name: "IX_Sightings_UserId",
                table: "Sightings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sightings");
        }
    }
}
