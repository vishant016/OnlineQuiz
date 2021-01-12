using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Quiz.Data.Migrations
{
    public partial class quiz9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObtainedMarks",
                table: "AnswerSheets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitTime",
                table: "AnswerSheets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObtainedMarks",
                table: "AnswerSheets");

            migrationBuilder.DropColumn(
                name: "SubmitTime",
                table: "AnswerSheets");
        }
    }
}
