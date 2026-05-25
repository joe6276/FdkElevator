using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projects_retake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectTeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectTeamId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "projectTeams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_UserId",
                table: "projectTeams",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_projectTeams_Users_UserId",
                table: "projectTeams",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectTeams_Users_UserId",
                table: "projectTeams");

            migrationBuilder.DropIndex(
                name: "IX_projectTeams_UserId",
                table: "projectTeams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "projectTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTeamId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectTeamId",
                table: "Users",
                column: "ProjectTeamId");

        }
    }
}
