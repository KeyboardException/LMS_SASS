using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_SASS.Migrations
{
    /// <inheritdoc />
    public partial class AddModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttemptDetails_QuizAttempts_QuizAttemptId",
                table: "QuizAttemptDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttemptDetails_QuizQuestions_QuestionId",
                table: "QuizAttemptDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttemptDetails_QuestionId",
                table: "QuizAttemptDetails");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttemptDetails_QuizAttemptId",
                table: "QuizAttemptDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuizAttemptDetails_QuestionId",
                table: "QuizAttemptDetails",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttemptDetails_QuizAttemptId",
                table: "QuizAttemptDetails",
                column: "QuizAttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttemptDetails_QuizAttempts_QuizAttemptId",
                table: "QuizAttemptDetails",
                column: "QuizAttemptId",
                principalTable: "QuizAttempts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttemptDetails_QuizQuestions_QuestionId",
                table: "QuizAttemptDetails",
                column: "QuestionId",
                principalTable: "QuizQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
