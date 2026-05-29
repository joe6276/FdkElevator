using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class materials_added1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_projects_ProjectId",
                table: "Material");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "materials");

            migrationBuilder.RenameIndex(
                name: "IX_Material_ProjectId",
                table: "materials",
                newName: "IX_materials_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_materials",
                table: "materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_projects_ProjectId",
                table: "materials",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_projects_ProjectId",
                table: "materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materials",
                table: "materials");

            migrationBuilder.RenameTable(
                name: "materials",
                newName: "Material");

            migrationBuilder.RenameIndex(
                name: "IX_materials_ProjectId",
                table: "Material",
                newName: "IX_Material_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_projects_ProjectId",
                table: "Material",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
