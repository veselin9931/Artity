using Microsoft.EntityFrameworkCore.Migrations;

namespace Artity.Data.Migrations
{
    public partial class AddPerformenceFieldOnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerformenceId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PerformenceId",
                table: "Orders",
                column: "PerformenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Performences_PerformenceId",
                table: "Orders",
                column: "PerformenceId",
                principalTable: "Performences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Performences_PerformenceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PerformenceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PerformenceId",
                table: "Orders");
        }
    }
}
