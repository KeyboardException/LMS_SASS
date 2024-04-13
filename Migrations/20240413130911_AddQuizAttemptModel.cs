using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_SASS.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizAttemptModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Assignment_AssignmentId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmissions_Users_UserId",
                table: "AssignmentSubmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmissions",
                newName: "AssignmentSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_UserId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmissions_AssignmentId",
                table: "AssignmentSubmission",
                newName: "IX_AssignmentSubmission_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Correct = table.Column<int>(type: "int", nullable: false),
                    Wrong = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAttempts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_QuizId",
                table: "QuizAttempts",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_UserId",
                table: "QuizAttempts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Assignment_AssignmentId",
                table: "AssignmentSubmission",
                column: "AssignmentId",
                principalTable: "Assignment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentSubmission_Users_UserId",
                table: "AssignmentSubmission",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Assignment_AssignmentId",
                table: "AssignmentSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentSubmission_Users_UserId",
                table: "AssignmentSubmission");

            migrationBuilder.DropTable(
                name: "QuizAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignmentSubmission",
                table: "AssignmentSubmission");

            migrationBuilder.RenameTable(
                name: "AssignmentSubmission",
                newName: "AssignmentSubmissions");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_UserId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentSubmission_AssignmentId",
                table: "AssignmentSubmissions",
                newName: "IX_AssignmentSubmissions_AssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignmentSubmissions",
                table: "AssignmentSubmissions",
                column: "Id");

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
    }
}
