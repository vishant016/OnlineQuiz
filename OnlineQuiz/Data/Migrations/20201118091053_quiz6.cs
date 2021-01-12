using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaperId",
                table: "AnswerSheets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheets_PaperId",
                table: "AnswerSheets",
                column: "PaperId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerSheets_Papers_PaperId",
                table: "AnswerSheets",
                column: "PaperId",
                principalTable: "Papers",
                principalColumn: "PaperId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerSheets_Papers_PaperId",
                table: "AnswerSheets");

            migrationBuilder.DropIndex(
                name: "IX_AnswerSheets_PaperId",
                table: "AnswerSheets");

            migrationBuilder.DropColumn(
                name: "PaperId",
                table: "AnswerSheets");
        }
    }
}
