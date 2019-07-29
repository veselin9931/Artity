using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class NormalizeRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "RatedId",
                table: "Ratings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatedId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Ratings");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Ratings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
