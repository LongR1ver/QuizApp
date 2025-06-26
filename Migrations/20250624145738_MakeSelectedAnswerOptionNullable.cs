using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp2.Migrations
{
    /// <inheritdoc />
    public partial class MakeSelectedAnswerOptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttemptAnswers_AnswerOptions_SelectedAnswerOptionId",
                table: "QuizAttemptAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedAnswerOptionId",
                table: "QuizAttemptAnswers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttemptAnswers_AnswerOptions_SelectedAnswerOptionId",
                table: "QuizAttemptAnswers",
                column: "SelectedAnswerOptionId",
                principalTable: "AnswerOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttemptAnswers_AnswerOptions_SelectedAnswerOptionId",
                table: "QuizAttemptAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedAnswerOptionId",
                table: "QuizAttemptAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttemptAnswers_AnswerOptions_SelectedAnswerOptionId",
                table: "QuizAttemptAnswers",
                column: "SelectedAnswerOptionId",
                principalTable: "AnswerOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
