using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projects_reorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "projectTeams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "projectTeams");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "projectTeams");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "projectTeams");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTeamId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectTeamId",
                table: "Users",
                column: "ProjectTeamId");

     
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
  

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectTeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectTeamId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "projectTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "projectTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "projectTeams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "projectTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
