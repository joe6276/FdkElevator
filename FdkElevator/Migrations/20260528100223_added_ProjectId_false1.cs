using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_ProjectId_false1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProducts_Users_userId",
                table: "SelectedProducts");

            migrationBuilder.DropIndex(
                name: "IX_SelectedProducts_userId",
                table: "SelectedProducts");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "SelectedProducts");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProducts_approvedBy",
                table: "SelectedProducts",
                column: "approvedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProducts_Users_approvedBy",
                table: "SelectedProducts",
                column: "approvedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectedProducts_Users_approvedBy",
                table: "SelectedProducts");

            migrationBuilder.DropIndex(
                name: "IX_SelectedProducts_approvedBy",
                table: "SelectedProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "SelectedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SelectedProducts_userId",
                table: "SelectedProducts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedProducts_Users_userId",
                table: "SelectedProducts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
