using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class Quiz3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Papers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Options",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Correct",
                table: "Options",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "OptionId");

            migrationBuilder.CreateTable(
                name: "AttendeeQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(nullable: true),
                    QuestionId = table.Column<int>(nullable: true),
                    PaperId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendeeQuestions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "OptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendeeQuestions_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "PaperId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendeeQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_OptionId",
                table: "AttendeeQuestions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_PaperId",
                table: "AttendeeQuestions",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeQuestions_QuestionId",
                table: "AttendeeQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "Correct",
                table: "Options");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");
        }
    }
}
