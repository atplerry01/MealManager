using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManager.Api.Migrations
{
    public partial class MealProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MealProfilingId",
                table: "MealTransaction",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MealEntitled = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealAssignment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealProfiling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    MealAssignmentId = table.Column<int>(nullable: true)
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
                name: "IX_MealTransaction_MealProfilingId",
                table: "MealTransaction",
                column: "MealProfilingId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealTransaction_MealProfiling_MealProfilingId",
                table: "MealTransaction");

            migrationBuilder.DropTable(
                name: "MealProfiling");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "MealAssignment");

            migrationBuilder.DropIndex(
                name: "IX_MealTransaction_MealProfilingId",
                table: "MealTransaction");

            migrationBuilder.DropColumn(
                name: "MealProfilingId",
                table: "MealTransaction");

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
    }
}
