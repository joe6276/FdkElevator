using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class add_civic_readiness_naming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CivilReadiness_projects_ProjectId",
                table: "CivilReadiness");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilReadiness",
                table: "CivilReadiness");

            migrationBuilder.RenameTable(
                name: "CivilReadiness",
                newName: "CivilReadinesses");

            migrationBuilder.RenameIndex(
                name: "IX_CivilReadiness_ProjectId",
                table: "CivilReadinesses",
                newName: "IX_CivilReadinesses_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilReadinesses",
                table: "CivilReadinesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CivilReadinesses_projects_ProjectId",
                table: "CivilReadinesses",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CivilReadinesses_projects_ProjectId",
                table: "CivilReadinesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CivilReadinesses",
                table: "CivilReadinesses");

            migrationBuilder.RenameTable(
                name: "CivilReadinesses",
                newName: "CivilReadiness");

            migrationBuilder.RenameIndex(
                name: "IX_CivilReadinesses_ProjectId",
                table: "CivilReadiness",
                newName: "IX_CivilReadiness_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CivilReadiness",
                table: "CivilReadiness",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CivilReadiness_projects_ProjectId",
                table: "CivilReadiness",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
