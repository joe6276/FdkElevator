using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_survey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PitDepth = table.Column<int>(type: "int", nullable: false),
                    numberofStops = table.Column<int>(type: "int", nullable: false),
                    ShaftWidth = table.Column<int>(type: "int", nullable: false),
                    ShaftDepth = table.Column<int>(type: "int", nullable: false),
                    OverheadClearance = table.Column<int>(type: "int", nullable: false),
                    PowerSupply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivicReady = table.Column<bool>(type: "bit", nullable: false),
                    MachineRoom = table.Column<bool>(type: "bit", nullable: false),
                    MLROption = table.Column<bool>(type: "bit", nullable: false),
                    ShaftAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CivicWorkRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecommendedLift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineerNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Surveys_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_SurveyorId",
                        column: x => x.SurveyorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_LeadId",
                table: "Surveys",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyorId",
                table: "Surveys",
                column: "SurveyorId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_TenantId",
                table: "Surveys",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
