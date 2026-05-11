using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_foreigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Surveys_LeadId",
                table: "Surveys");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_LeadId",
                table: "Surveys",
                column: "LeadId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Surveys_LeadId",
                table: "Surveys");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_LeadId",
                table: "Surveys",
                column: "LeadId");
        }
    }
}
