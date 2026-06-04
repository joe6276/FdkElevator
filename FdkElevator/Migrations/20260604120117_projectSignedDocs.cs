using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projectSignedDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSignedDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSignedDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSignedDoc_Users_SignedBy",
                        column: x => x.SignedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSignedDoc_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSignedDoc_ProjectId",
                table: "ProjectSignedDoc",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSignedDoc_SignedBy",
                table: "ProjectSignedDoc",
                column: "SignedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSignedDoc");
        }
    }
}
