using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class updated_revisions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QuotationId",
                table: "revisions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_revisions_QuotationId",
                table: "revisions",
                column: "QuotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_revisions_Quotations_QuotationId",
                table: "revisions",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_revisions_Quotations_QuotationId",
                table: "revisions");

            migrationBuilder.DropIndex(
                name: "IX_revisions_QuotationId",
                table: "revisions");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "revisions");
        }
    }
}
