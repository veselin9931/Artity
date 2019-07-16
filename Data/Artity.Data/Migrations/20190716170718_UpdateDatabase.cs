using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Songs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Ratings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ratings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Ratings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Pictures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pictures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Pictures",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Performences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Performences",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Performences",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Performences",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Offerts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Offerts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Offerts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Offerts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Artists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Artists",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Artists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_IsDeleted",
                table: "Songs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IsDeleted",
                table: "Ratings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Performences_IsDeleted",
                table: "Performences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Offerts_IsDeleted",
                table: "Offerts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_IsDeleted",
                table: "Artists",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_IsDeleted",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_IsDeleted",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Performences_IsDeleted",
                table: "Performences");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Offerts_IsDeleted",
                table: "Offerts");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Artists_IsDeleted",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Performences");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Offerts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Artists");
        }
    }
}
