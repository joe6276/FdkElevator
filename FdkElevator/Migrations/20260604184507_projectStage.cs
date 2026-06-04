using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projectStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_ProjectPhases_ProjectPhaseId",
                table: "projectTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectPhaseId",
                table: "projectTasks",
                newName: "ProjectStageId");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_ProjectPhaseId",
                table: "projectTasks",
                newName: "IX_projectTasks_ProjectStageId");

            migrationBuilder.CreateTable(
                name: "projectStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StageCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dependency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectStages_ProjectPhases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "ProjectPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectStages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projectStages_PhaseId",
                table: "projectStages",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_projectStages_UserId",
                table: "projectStages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_projectStages_ProjectStageId",
                table: "projectTasks",
                column: "ProjectStageId",
                principalTable: "projectStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_projectStages_ProjectStageId",
                table: "projectTasks");

            migrationBuilder.DropTable(
                name: "projectStages");

            migrationBuilder.RenameColumn(
                name: "ProjectStageId",
                table: "projectTasks",
                newName: "ProjectPhaseId");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_ProjectStageId",
                table: "projectTasks",
                newName: "IX_projectTasks_ProjectPhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_ProjectPhases_ProjectPhaseId",
                table: "projectTasks",
                column: "ProjectPhaseId",
                principalTable: "ProjectPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
