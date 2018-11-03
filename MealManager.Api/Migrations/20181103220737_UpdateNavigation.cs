using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManager.Api.Migrations
{
    public partial class UpdateNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMealProfiling_Department_DepartmentId",
                table: "DepartmentMealProfiling");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMealProfiling_MealAssignment_MealAssignmentId",
                table: "DepartmentMealProfiling");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_Menu_MenuId",
                table: "MealTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_AspNetUsers_UserId",
                table: "MealTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMealProfiling_DepartmentMealProfiling_DepartmentMealProfilingId",
                table: "UserMealProfiling");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MealTransaction",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTransaction_UserId",
                table: "MealTransaction",
                newName: "IX_MealTransaction_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentMealProfilingId",
                table: "UserMealProfiling",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MealTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserMealProfileId",
                table: "MealTransaction",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MealAssignmentId",
                table: "DepartmentMealProfiling",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DepartmentMealProfiling",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMealProfiling_Department_DepartmentId",
                table: "DepartmentMealProfiling",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMealProfiling_MealAssignment_MealAssignmentId",
                table: "DepartmentMealProfiling",
                column: "MealAssignmentId",
                principalTable: "MealAssignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_AspNetUsers_ApplicationUserId",
                table: "MealTransaction",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_Menu_MenuId",
                table: "MealTransaction",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMealProfiling_DepartmentMealProfiling_DepartmentMealProfilingId",
                table: "UserMealProfiling",
                column: "DepartmentMealProfilingId",
                principalTable: "DepartmentMealProfiling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMealProfiling_Department_DepartmentId",
                table: "DepartmentMealProfiling");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentMealProfiling_MealAssignment_MealAssignmentId",
                table: "DepartmentMealProfiling");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_AspNetUsers_ApplicationUserId",
                table: "MealTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_Menu_MenuId",
                table: "MealTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMealProfiling_DepartmentMealProfiling_DepartmentMealProfilingId",
                table: "UserMealProfiling");

            migrationBuilder.DropColumn(
                name: "UserMealProfileId",
                table: "MealTransaction");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "MealTransaction",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTransaction_ApplicationUserId",
                table: "MealTransaction",
                newName: "IX_MealTransaction_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentMealProfilingId",
                table: "UserMealProfiling",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MealTransaction",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MealAssignmentId",
                table: "DepartmentMealProfiling",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DepartmentMealProfiling",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMealProfiling_Department_DepartmentId",
                table: "DepartmentMealProfiling",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentMealProfiling_MealAssignment_MealAssignmentId",
                table: "DepartmentMealProfiling",
                column: "MealAssignmentId",
                principalTable: "MealAssignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_Menu_MenuId",
                table: "MealTransaction",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_AspNetUsers_UserId",
                table: "MealTransaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMealProfiling_DepartmentMealProfiling_DepartmentMealProfilingId",
                table: "UserMealProfiling",
                column: "DepartmentMealProfilingId",
                principalTable: "DepartmentMealProfiling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
