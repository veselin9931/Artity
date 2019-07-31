using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class ChanegOrderField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssuedOn",
                table: "Orders",
                newName: "EventDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Orders",
                newName: "IssuedOn");
        }
    }
}
