using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEvaluation.DAL.Migrations
{
    public partial class ProjectGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judges_Projects_ProjectId",
                table: "Judges");

            migrationBuilder.DropIndex(
                name: "IX_Judges_ProjectId",
                table: "Judges");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Judges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Judges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Judges_ProjectId",
                table: "Judges",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Projects_ProjectId",
                table: "Judges",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
