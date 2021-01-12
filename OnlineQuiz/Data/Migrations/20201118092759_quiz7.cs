using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Optionid",
                table: "AnswerSheet_Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheet_Questions_Optionid",
                table: "AnswerSheet_Questions",
                column: "Optionid");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheet_Questions_Options_Optionid",
                table: "AnswerSheet_Questions",
                column: "Optionid",
                principalTable: "Options",
                principalColumn: "OptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheet_Questions_Options_Optionid",
                table: "AnswerSheet_Questions");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSheet_Questions_Optionid",
                table: "AnswerSheet_Questions");

            migrationBuilder.DropColumn(
                name: "Optionid",
                table: "AnswerSheet_Questions");
        }
    }
}
