using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quotations_ClientId",
                table: "Quotations");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientId",
                table: "Quotations",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quotations_ClientId",
                table: "Quotations");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientId",
                table: "Quotations",
                column: "ClientId",
                unique: true);
        }
    }
}
