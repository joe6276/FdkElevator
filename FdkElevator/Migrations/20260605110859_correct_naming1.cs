using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class correct_naming1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_certificates_IssuedBy",
                table: "certificates");

            migrationBuilder.CreateIndex(
                name: "IX_certificates_IssuedBy",
                table: "certificates",
                column: "IssuedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_certificates_IssuedBy",
                table: "certificates");

            migrationBuilder.CreateIndex(
                name: "IX_certificates_IssuedBy",
                table: "certificates",
                column: "IssuedBy",
                unique: true);
        }
    }
}
