using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEvaluation.DAL.Migrations
{
    public partial class judgesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judge_Projects_ProjectId",
                table: "Judge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Judge",
                table: "Judge");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "Judge");

            migrationBuilder.RenameTable(
                name: "Judge",
                newName: "Judges");

            migrationBuilder.RenameIndex(
                name: "IX_Judge_ProjectId",
                table: "Judges",
                newName: "IX_Judges_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Judges",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Judges",
                table: "Judges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Projects_ProjectId",
                table: "Judges",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judges_Projects_ProjectId",
                table: "Judges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Judges",
                table: "Judges");

            migrationBuilder.RenameTable(
                name: "Judges",
                newName: "Judge");

            migrationBuilder.RenameIndex(
                name: "IX_Judges_ProjectId",
                table: "Judge",
                newName: "IX_Judge_ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Judge",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Evaluation",
                table: "Judge",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Judge",
                table: "Judge",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Judge_Projects_ProjectId",
                table: "Judge",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
