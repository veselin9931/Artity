using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class ValidationPPerformence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerformenceId",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Performences",
                maxLength: 888,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PerformencePhotoId",
                table: "Performences",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PerformenceId",
                table: "Pictures",
                column: "PerformenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Performences_PerformencePhotoId",
                table: "Performences",
                column: "PerformencePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performences_Pictures_PerformencePhotoId",
                table: "Performences",
                column: "PerformencePhotoId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Performences_PerformenceId",
                table: "Pictures",
                column: "PerformenceId",
                principalTable: "Performences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performences_Pictures_PerformencePhotoId",
                table: "Performences");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Performences_PerformenceId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PerformenceId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Performences_PerformencePhotoId",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "PerformenceId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PerformencePhotoId",
                table: "Performences");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Performences",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 888);
        }
    }
}
