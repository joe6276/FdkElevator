using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_project_tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_projects_ProjectId",
                table: "projectTasks");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "projectTasks",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "projectTasks",
                newName: "PlannedStart");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_ProjectId",
                table: "projectTasks",
                newName: "IX_projectTasks_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "projectTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Criticality",
                table: "projectTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedEnd",
                table: "projectTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectPhaseId",
                table: "projectTasks",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_projectTasks_ProjectPhaseId",
                table: "projectTasks",
                column: "ProjectPhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_ProjectPhases_ProjectPhaseId",
                table: "projectTasks",
                column: "ProjectPhaseId",
                principalTable: "ProjectPhases",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);


            migrationBuilder.Sql(
         "DELETE FROM [projectTasks] WHERE [UserId] NOT IN (SELECT [Id] FROM [Users])");

            // Step 2: Now safely add the FK
            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_Users_UserId",
                table: "projectTasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_ProjectPhases_ProjectPhaseId",
                table: "projectTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_projectTasks_Users_UserId",
                table: "projectTasks");

            migrationBuilder.DropIndex(
                name: "IX_projectTasks_ProjectPhaseId",
                table: "projectTasks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "projectTasks");

            migrationBuilder.DropColumn(
                name: "Criticality",
                table: "projectTasks");

            migrationBuilder.DropColumn(
                name: "PlannedEnd",
                table: "projectTasks");

            migrationBuilder.DropColumn(
                name: "ProjectPhaseId",
                table: "projectTasks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "projectTasks",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "PlannedStart",
                table: "projectTasks",
                newName: "DueDate");

            migrationBuilder.RenameIndex(
                name: "IX_projectTasks_UserId",
                table: "projectTasks",
                newName: "IX_projectTasks_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectTasks_projects_ProjectId",
                table: "projectTasks",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
