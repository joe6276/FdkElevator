using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_order3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierItemId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SupplierItemId",
                table: "OrderItems",
                column: "SupplierItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_supplierItems_SupplierItemId",
                table: "OrderItems",
                column: "SupplierItemId",
                principalTable: "supplierItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_supplierItems_SupplierItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SupplierItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SupplierItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "OrderItems",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
