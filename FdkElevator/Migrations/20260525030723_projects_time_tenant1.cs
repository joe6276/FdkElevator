using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projects_time_tenant1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "projectTasks",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "projectTasks",
                newName: "Name");
        }
    }
}
