using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class changed_Complaint_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "JobClosures");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceURL",
                table: "JobClosures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceURL",
                table: "JobClosures");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "JobClosures",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
