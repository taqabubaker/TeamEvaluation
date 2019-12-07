using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEvaluation.DAL.Migrations
{
    public partial class mm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterias_Projects_ProjectId",
                table: "Criterias");

            migrationBuilder.DropIndex(
                name: "IX_Criterias_ProjectId",
                table: "Criterias");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Criterias");

            migrationBuilder.CreateTable(
                name: "ProjectsCriterias",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    CriteriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsCriterias", x => new { x.ProjectId, x.CriteriaId });
                    table.ForeignKey(
                        name: "FK_ProjectsCriterias_Criterias_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "Criterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsCriterias_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsCriterias_CriteriaId",
                table: "ProjectsCriterias",
                column: "CriteriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsCriterias");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Criterias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Criterias_ProjectId",
                table: "Criterias",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterias_Projects_ProjectId",
                table: "Criterias",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
