using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class AddPlaceAndDurationOnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Orders");
        }
    }
}
