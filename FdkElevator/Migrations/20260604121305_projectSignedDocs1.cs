using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class projectSignedDocs1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSignedDoc_Users_SignedBy",
                table: "ProjectSignedDoc");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSignedDoc_projects_ProjectId",
                table: "ProjectSignedDoc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSignedDoc",
                table: "ProjectSignedDoc");

            migrationBuilder.RenameTable(
                name: "ProjectSignedDoc",
                newName: "projectSignedDocs");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSignedDoc_SignedBy",
                table: "projectSignedDocs",
                newName: "IX_projectSignedDocs_SignedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectSignedDoc_ProjectId",
                table: "projectSignedDocs",
                newName: "IX_projectSignedDocs_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projectSignedDocs",
                table: "projectSignedDocs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_projectSignedDocs_Users_SignedBy",
                table: "projectSignedDocs",
                column: "SignedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projectSignedDocs_projects_ProjectId",
                table: "projectSignedDocs",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectSignedDocs_Users_SignedBy",
                table: "projectSignedDocs");

            migrationBuilder.DropForeignKey(
                name: "FK_projectSignedDocs_projects_ProjectId",
                table: "projectSignedDocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projectSignedDocs",
                table: "projectSignedDocs");

            migrationBuilder.RenameTable(
                name: "projectSignedDocs",
                newName: "ProjectSignedDoc");

            migrationBuilder.RenameIndex(
                name: "IX_projectSignedDocs_SignedBy",
                table: "ProjectSignedDoc",
                newName: "IX_ProjectSignedDoc_SignedBy");

            migrationBuilder.RenameIndex(
                name: "IX_projectSignedDocs_ProjectId",
                table: "ProjectSignedDoc",
                newName: "IX_ProjectSignedDoc_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSignedDoc",
                table: "ProjectSignedDoc",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSignedDoc_Users_SignedBy",
                table: "ProjectSignedDoc",
                column: "SignedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSignedDoc_projects_ProjectId",
                table: "ProjectSignedDoc",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
