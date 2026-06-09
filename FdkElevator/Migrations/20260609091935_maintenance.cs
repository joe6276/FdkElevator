using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class maintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_projectMaintenances_ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropTable(
                name: "projectMaintenancePayments");

            migrationBuilder.DropTable(
                name: "reportAttachments");

            migrationBuilder.DropTable(
                name: "projectMaintenances");

            migrationBuilder.DropTable(
                name: "technicianReports");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_ProjectId",
                table: "MaintenanceSchedules",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_projects_ProjectId",
                table: "MaintenanceSchedules",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_projects_ProjectId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_ProjectId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "MaintenanceSchedules");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "projectMaintenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMCContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectMaintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectMaintenances_AMCContracts_AMCContractId",
                        column: x => x.AMCContractId,
                        principalTable: "AMCContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    NextVisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectMaintenancePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectMaintenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentReceiptImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPaid = table.Column<bool>(type: "bit", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_MaintenanceSchedules_ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                column: "ProjectMaintenancesId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenancePayments_ClientId",
                table: "projectMaintenancePayments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenancePayments_ProjectMaintenanceId",
                table: "projectMaintenancePayments",
                column: "ProjectMaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenances_AMCContractId",
                table: "projectMaintenances",
                column: "AMCContractId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_projectMaintenances_ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                column: "ProjectMaintenancesId",
                principalTable: "projectMaintenances",
                principalColumn: "Id");
        }
    }
}
