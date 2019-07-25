using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class PerformenceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Еngagement",
                table: "Offerts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Performences",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 888);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Performences",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Offerts",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Offerts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Contract",
                table: "Offerts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Offerts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Offerts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offerts",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Offerts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Performences_CategoryId",
                table: "Performences",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performences_Categories_CategoryId",
                table: "Performences",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performences_Categories_CategoryId",
                table: "Performences");

            migrationBuilder.DropIndex(
                name: "IX_Performences_CategoryId",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "Contract",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Offerts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Performences",
                maxLength: 888,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50000);

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Offerts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistId",
                table: "Offerts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "Еngagement",
                table: "Offerts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
