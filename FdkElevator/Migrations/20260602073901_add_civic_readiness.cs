using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class add_civic_readiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialNotes",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsOfPayments",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CivilReadiness",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Shaft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overhead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerSupply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyBarricades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiftingPoints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingReadiness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilReadiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CivilReadiness_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CivilReadiness_ProjectId",
                table: "CivilReadiness",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CivilReadiness");

            migrationBuilder.DropColumn(
                name: "SpecialNotes",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TermsOfPayments",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Tenants");
        }
    }
}
