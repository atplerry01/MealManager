using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManager.Api.Migrations
{
    public partial class UpdateMealProfile1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MealTransaction",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealTransaction_UserId",
                table: "MealTransaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_AspNetUsers_UserId",
                table: "MealTransaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_AspNetUsers_UserId",
                table: "MealTransaction");

            migrationBuilder.DropIndex(
                name: "IX_MealTransaction_UserId",
                table: "MealTransaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealTransaction");
        }
    }
}
