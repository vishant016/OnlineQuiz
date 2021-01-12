using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class Quiz2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionName",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaperName",
                table: "Papers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionName",
                table: "Options",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionName",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "PaperName",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "OptionName",
                table: "Options");
        }
    }
}
