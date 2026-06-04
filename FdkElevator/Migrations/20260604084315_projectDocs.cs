using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projectDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectDocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectDocs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectDocs");
        }
    }
}
