using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class project_maintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectMaintenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectMaintenances_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "technicianReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextVisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicianReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_technicianReports_Users_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_technicianReports_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AMCContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coverage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPMVisits = table.Column<int>(type: "int", nullable: false),
                    IncludedParts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcludedParts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SLA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EscalationContacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RenewalReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMCContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AMCContracts_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AMCContracts_projectMaintenances_ProjectMaintenanceId",
                        column: x => x.ProjectMaintenanceId,
                        principalTable: "projectMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "maintenanceSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedTechnician = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenanceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_maintenanceSchedules_Users_AssignedTechnician",
                        column: x => x.AssignedTechnician,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_maintenanceSchedules_projectMaintenances_projectMaintenanceId",
                        column: x => x.projectMaintenanceId,
                        principalTable: "projectMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "projectMaintenancePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentReceiptImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectMaintenancePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectMaintenancePayments_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectMaintenancePayments_projectMaintenances_ProjectMaintenanceId",
                        column: x => x.ProjectMaintenanceId,
                        principalTable: "projectMaintenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "reportAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reportAttachments_technicianReports_TechnicianReportId",
                        column: x => x.TechnicianReportId,
                        principalTable: "technicianReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AMCContracts_ClientId",
                table: "AMCContracts",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AMCContracts_ProjectMaintenanceId",
                table: "AMCContracts",
                column: "ProjectMaintenanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_maintenanceSchedules_AssignedTechnician",
                table: "maintenanceSchedules",
                column: "AssignedTechnician");

            migrationBuilder.CreateIndex(
                name: "IX_maintenanceSchedules_projectMaintenanceId",
                table: "maintenanceSchedules",
                column: "projectMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenancePayments_ClientId",
                table: "projectMaintenancePayments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenancePayments_ProjectMaintenanceId",
                table: "projectMaintenancePayments",
                column: "ProjectMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenances_ProjectId",
                table: "projectMaintenances",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_reportAttachments_TechnicianReportId",
                table: "reportAttachments",
                column: "TechnicianReportId");

            migrationBuilder.CreateIndex(
                name: "IX_technicianReports_ProjectId",
                table: "technicianReports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_technicianReports_TechnicianId",
                table: "technicianReports",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AMCContracts");

            migrationBuilder.DropTable(
                name: "maintenanceSchedules");

            migrationBuilder.DropTable(
                name: "projectMaintenancePayments");

            migrationBuilder.DropTable(
                name: "reportAttachments");

            migrationBuilder.DropTable(
                name: "projectMaintenances");

            migrationBuilder.DropTable(
                name: "technicianReports");
        }
    }
}
