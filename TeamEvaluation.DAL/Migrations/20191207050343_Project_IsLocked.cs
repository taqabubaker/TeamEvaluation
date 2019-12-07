using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEvaluation.DAL.Migrations
{
    public partial class Project_IsLocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Projects",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Projects");
        }
    }
}
