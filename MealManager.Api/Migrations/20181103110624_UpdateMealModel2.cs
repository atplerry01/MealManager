using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManager.Api.Migrations
{
    public partial class UpdateMealModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_MealProfiling_MealProfilingId",
                table: "MealTransaction");

            migrationBuilder.DropTable(
                name: "MealProfiling");

            migrationBuilder.RenameColumn(
                name: "MealProfilingId",
                table: "MealTransaction",
                newName: "UserMealProfilingId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTransaction_MealProfilingId",
                table: "MealTransaction",
                newName: "IX_MealTransaction_UserMealProfilingId");

            migrationBuilder.AddColumn<string>(
                name: "JobFunction",
                table: "Department",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentMealProfiling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    MealAssignmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentMealProfiling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentMealProfiling_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentMealProfiling_MealAssignment_MealAssignmentId",
                        column: x => x.MealAssignmentId,
                        principalTable: "MealAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMealProfiling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    DepartmentMealProfilingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMealProfiling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMealProfiling_DepartmentMealProfiling_DepartmentMealProfilingId",
                        column: x => x.DepartmentMealProfilingId,
                        principalTable: "DepartmentMealProfiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMealProfiling_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMealProfiling_DepartmentId",
                table: "DepartmentMealProfiling",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMealProfiling_MealAssignmentId",
                table: "DepartmentMealProfiling",
                column: "MealAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealProfiling_DepartmentMealProfilingId",
                table: "UserMealProfiling",
                column: "DepartmentMealProfilingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealProfiling_UserId",
                table: "UserMealProfiling",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_UserMealProfiling_UserMealProfilingId",
                table: "MealTransaction",
                column: "UserMealProfilingId",
                principalTable: "UserMealProfiling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_UserMealProfiling_UserMealProfilingId",
                table: "MealTransaction");

            migrationBuilder.DropTable(
                name: "UserMealProfiling");

            migrationBuilder.DropTable(
                name: "DepartmentMealProfiling");

            migrationBuilder.DropColumn(
                name: "JobFunction",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "UserMealProfilingId",
                table: "MealTransaction",
                newName: "MealProfilingId");

            migrationBuilder.RenameIndex(
                name: "IX_MealTransaction_UserMealProfilingId",
                table: "MealTransaction",
                newName: "IX_MealTransaction_MealProfilingId");

            migrationBuilder.CreateTable(
                name: "MealProfiling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: true),
                    MealAssignmentId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealProfiling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealProfiling_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealProfiling_MealAssignment_MealAssignmentId",
                        column: x => x.MealAssignmentId,
                        principalTable: "MealAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealProfiling_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealProfiling_DepartmentId",
                table: "MealProfiling",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MealProfiling_MealAssignmentId",
                table: "MealProfiling",
                column: "MealAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MealProfiling_UserId",
                table: "MealProfiling",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealTransaction_MealProfiling_MealProfilingId",
                table: "MealTransaction",
                column: "MealProfilingId",
                principalTable: "MealProfiling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
