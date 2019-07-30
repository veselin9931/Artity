using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class ChanegRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Artists_ArtistId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Performences_PerformenceId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ArtistId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_PerformenceId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "PerformenceId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Performences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArtistId",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerformenceId",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Performences",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ArtistId",
                table: "Ratings",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PerformenceId",
                table: "Ratings",
                column: "PerformenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Artists_ArtistId",
                table: "Ratings",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Performences_PerformenceId",
                table: "Ratings",
                column: "PerformenceId",
                principalTable: "Performences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
