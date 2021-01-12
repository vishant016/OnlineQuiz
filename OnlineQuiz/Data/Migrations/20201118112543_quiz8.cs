using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "AnswerSheets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "AnswerSheets");
        }
    }
}
