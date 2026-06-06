using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class breakdowm1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SLAConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsAMC = table.Column<bool>(type: "bit", nullable: false),
                    ResponseTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    ArrivalTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    ResolutionTimeHours = table.Column<int>(type: "int", nullable: false),
                    PenaltyTerms = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLAConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "breakdownComplaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    QRCodeReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsAppMessageRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReportedByExternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedByPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaultType = table.Column<int>(type: "int", nullable: false),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerTrapped = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsAMCClient = table.Column<bool>(type: "bit", nullable: false),
                    SLAConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SLAResponseDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLAResolutionDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLAStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsRepeatedFault = table.Column<bool>(type: "bit", nullable: false),
                    RepeatCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breakdownComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breakdownComplaints_SLAConfigurations_SLAConfigId",
                        column: x => x.SLAConfigId,
                        principalTable: "SLAConfigurations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_breakdownComplaints_Users_ReportedByUserId",
                        column: x => x.ReportedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_breakdownComplaints_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "breakdownDispatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakdownComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DispatchedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DispatchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DispatchNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breakdownDispatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breakdownDispatches_Users_DispatchedById",
                        column: x => x.DispatchedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_breakdownDispatches_Users_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_breakdownDispatches_breakdownComplaints_BreakdownComplaintId",
                        column: x => x.BreakdownComplaintId,
                        principalTable: "breakdownComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobClosures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakdownComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosedByTechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiftRunningStatus = table.Column<int>(type: "int", nullable: false),
                    ServiceReportSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientSignatureObtained = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceTriggered = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepeatedFaultFlagged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobClosures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobClosures_Users_ClosedByTechnicianId",
                        column: x => x.ClosedByTechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobClosures_breakdownComplaints_BreakdownComplaintId",
                        column: x => x.BreakdownComplaintId,
                        principalTable: "breakdownComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RepairQuotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakdownComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LaborCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PartsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuotationDocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairQuotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairQuotations_Users_ApprovedByClientId",
                        column: x => x.ApprovedByClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairQuotations_breakdownComplaints_BreakdownComplaintId",
                        column: x => x.BreakdownComplaintId,
                        principalTable: "breakdownComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootCauseAnalyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakdownComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewedByManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RootCauseSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreakdownCountLast90Days = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<int>(type: "int", nullable: false),
                    ActionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedActionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModernizationProposalSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootCauseAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalyses_Users_ReviewedByManagerId",
                        column: x => x.ReviewedByManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalyses_breakdownComplaints_BreakdownComplaintId",
                        column: x => x.BreakdownComplaintId,
                        principalTable: "breakdownComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RootCauseAnalyses_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "technicianDiagnoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreakdownComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaultCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuspectedRootCause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentAffected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemporaryFixApplied = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentFixRequired = table.Column<bool>(type: "bit", nullable: false),
                    PermanentFixDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafetyStatus = table.Column<int>(type: "int", nullable: false),
                    DiagnosisDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technicianDiagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_technicianDiagnoses_Users_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_technicianDiagnoses_breakdownComplaints_BreakdownComplaintId",
                        column: x => x.BreakdownComplaintId,
                        principalTable: "breakdownComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuotationLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairQuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationLineItems_RepairQuotations_RepairQuotationId",
                        column: x => x.RepairQuotationId,
                        principalTable: "RepairQuotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnosisMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianDiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosisMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diagnosisMedias_technicianDiagnoses_TechnicianDiagnosisId",
                        column: x => x.TechnicianDiagnosisId,
                        principalTable: "technicianDiagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SparePartRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianDiagnosisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityNeeded = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SparePartRequests_technicianDiagnoses_TechnicianDiagnosisId",
                        column: x => x.TechnicianDiagnosisId,
                        principalTable: "technicianDiagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_breakdownComplaints_ProjectId",
                table: "breakdownComplaints",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_breakdownComplaints_ReportedByUserId",
                table: "breakdownComplaints",
                column: "ReportedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_breakdownComplaints_SLAConfigId",
                table: "breakdownComplaints",
                column: "SLAConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_breakdownDispatches_BreakdownComplaintId",
                table: "breakdownDispatches",
                column: "BreakdownComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_breakdownDispatches_DispatchedById",
                table: "breakdownDispatches",
                column: "DispatchedById");

            migrationBuilder.CreateIndex(
                name: "IX_breakdownDispatches_TechnicianId",
                table: "breakdownDispatches",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosisMedias_TechnicianDiagnosisId",
                table: "diagnosisMedias",
                column: "TechnicianDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_JobClosures_BreakdownComplaintId",
                table: "JobClosures",
                column: "BreakdownComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobClosures_ClosedByTechnicianId",
                table: "JobClosures",
                column: "ClosedByTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationLineItems_RepairQuotationId",
                table: "QuotationLineItems",
                column: "RepairQuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairQuotations_ApprovedByClientId",
                table: "RepairQuotations",
                column: "ApprovedByClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairQuotations_BreakdownComplaintId",
                table: "RepairQuotations",
                column: "BreakdownComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalyses_BreakdownComplaintId",
                table: "RootCauseAnalyses",
                column: "BreakdownComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalyses_ProjectId",
                table: "RootCauseAnalyses",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RootCauseAnalyses_ReviewedByManagerId",
                table: "RootCauseAnalyses",
                column: "ReviewedByManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartRequests_TechnicianDiagnosisId",
                table: "SparePartRequests",
                column: "TechnicianDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_technicianDiagnoses_BreakdownComplaintId",
                table: "technicianDiagnoses",
                column: "BreakdownComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_technicianDiagnoses_TechnicianId",
                table: "technicianDiagnoses",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breakdownDispatches");

            migrationBuilder.DropTable(
                name: "diagnosisMedias");

            migrationBuilder.DropTable(
                name: "JobClosures");

            migrationBuilder.DropTable(
                name: "QuotationLineItems");

            migrationBuilder.DropTable(
                name: "RootCauseAnalyses");

            migrationBuilder.DropTable(
                name: "SparePartRequests");

            migrationBuilder.DropTable(
                name: "RepairQuotations");

            migrationBuilder.DropTable(
                name: "technicianDiagnoses");

            migrationBuilder.DropTable(
                name: "breakdownComplaints");

            migrationBuilder.DropTable(
                name: "SLAConfigurations");
        }
    }
}
