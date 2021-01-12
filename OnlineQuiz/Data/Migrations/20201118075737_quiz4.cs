using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendeeQuestions_Options_OptionId",
                table: "AttendeeQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendeeQuestions_Questions_QuestionId",
                table: "AttendeeQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AttendeeQuestions_OptionId",
                table: "AttendeeQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AttendeeQuestions_QuestionId",
                table: "AttendeeQuestions");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "AttendeeQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "AttendeeQuestions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "AttendeeQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "AttendeeQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_OptionId",
                table: "AttendeeQuestions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_QuestionId",
                table: "AttendeeQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendeeQuestions_Options_OptionId",
                table: "AttendeeQuestions",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendeeQuestions_Questions_QuestionId",
                table: "AttendeeQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
