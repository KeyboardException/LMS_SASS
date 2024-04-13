using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_SASS.Migrations
{
    /// <inheritdoc />
    public partial class AddActivitiesModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissionsModel_Assignment_AssignmentId",
                table: "AssignmentSubmissionsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissionsModel_Users_UserId",
                table: "AssignmentSubmissionsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissionsModel",
                table: "AssignmentSubmissionsModel");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissionsModel",
                newName: "AssignmentSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissionsModel_UserId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissionsModel_AssignmentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CourseId",
                table: "Activities",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Assignment_AssignmentId",
                table: "AssignmentSubmissions",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissions_Users_UserId",
                table: "AssignmentSubmissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignment_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Users_UserId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissions",
                newName: "AssignmentSubmissionsModel");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_UserId",
                table: "AssignmentSubmissionsModel",
                newName: "IX_AssignmentSubmissionsModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmissionsModel",
                newName: "IX_AssignmentSubmissionsModel_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissionsModel",
                table: "AssignmentSubmissionsModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissionsModel_Assignment_AssignmentId",
                table: "AssignmentSubmissionsModel",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmissionsModel_Users_UserId",
                table: "AssignmentSubmissionsModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
