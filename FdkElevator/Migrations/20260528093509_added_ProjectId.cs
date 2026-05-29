using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_ProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "SelectedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProducts_ProjectId",
                table: "SelectedProducts",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProducts_projects_ProjectId",
                table: "SelectedProducts",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProducts_projects_ProjectId",
                table: "SelectedProducts");

            migrationBuilder.DropIndex(
                name: "IX_SelectedProducts_ProjectId",
                table: "SelectedProducts");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "SelectedProducts");
        }
    }
}
