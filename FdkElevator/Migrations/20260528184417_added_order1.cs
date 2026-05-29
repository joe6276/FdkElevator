using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_order1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TenantId",
                table: "Orders",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tenants_TenantId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TenantId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Orders");
        }
    }
}
