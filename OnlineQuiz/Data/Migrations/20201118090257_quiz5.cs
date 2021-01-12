using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeQuestions");

            migrationBuilder.CreateTable(
                name: "AnswerSheets",
                columns: table => new
                {
                    AnswerSheetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSheets", x => x.AnswerSheetId);
                });

            migrationBuilder.CreateTable(
                name: "AnswerSheet_Questions",
                columns: table => new
                {
                    AnswerSheetId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerSheet_Questions", x => new { x.AnswerSheetId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_AnswerSheet_Questions_AnswerSheets_AnswerSheetId",
                        column: x => x.AnswerSheetId,
                        principalTable: "AnswerSheets",
                        principalColumn: "AnswerSheetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerSheet_Questions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerSheet_Questions_QuestionId",
                table: "AnswerSheet_Questions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerSheet_Questions");

            migrationBuilder.DropTable(
                name: "AnswerSheets");

            migrationBuilder.CreateTable(
                name: "AttendeeQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendeeQuestions_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_PaperId",
                table: "AttendeeQuestions",
                column: "PaperId");
        }
    }
}
