using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class new_project_maintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AMCContracts_projectMaintenances_ProjectMaintenanceId",
                table: "AMCContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_maintenanceSchedules_Users_AssignedTechnician",
                table: "maintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_maintenanceSchedules_projectMaintenances_projectMaintenanceId",
                table: "maintenanceSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_maintenanceSchedules",
                table: "maintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_maintenanceSchedules_AssignedTechnician",
                table: "maintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AMCContracts_ProjectMaintenanceId",
                table: "AMCContracts");

            migrationBuilder.DropColumn(
                name: "AssignedTechnician",
                table: "maintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "maintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AMCContracts");

            migrationBuilder.RenameTable(
                name: "maintenanceSchedules",
                newName: "MaintenanceSchedules");

            migrationBuilder.RenameColumn(
                name: "projectMaintenanceId",
                table: "MaintenanceSchedules",
                newName: "LiftAssetId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MaintenanceSchedules",
                newName: "ScheduleType");

            migrationBuilder.RenameColumn(
                name: "ScheduledDate",
                table: "MaintenanceSchedules",
                newName: "NextDueDate");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "MaintenanceSchedules",
                newName: "Frequency");

            migrationBuilder.RenameIndex(
                name: "IX_maintenanceSchedules_projectMaintenanceId",
                table: "MaintenanceSchedules",
                newName: "IX_MaintenanceSchedules_LiftAssetId");

            migrationBuilder.RenameColumn(
                name: "SLA",
                table: "AMCContracts",
                newName: "SLAPolicy");

            migrationBuilder.RenameColumn(
                name: "RenewalReminderDate",
                table: "AMCContracts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ProjectMaintenanceId",
                table: "AMCContracts",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "PaymentSchedule",
                table: "AMCContracts",
                newName: "Inclusions");

            migrationBuilder.RenameColumn(
                name: "NumberOfPMVisits",
                table: "AMCContracts",
                newName: "ServiceFrequency");

            migrationBuilder.RenameColumn(
                name: "IncludedParts",
                table: "AMCContracts",
                newName: "Exclusions");

            migrationBuilder.RenameColumn(
                name: "ExcludedParts",
                table: "AMCContracts",
                newName: "CurrencyCode");

            migrationBuilder.RenameColumn(
                name: "EscalationContacts",
                table: "AMCContracts",
                newName: "ContractCode");

            migrationBuilder.RenameColumn(
                name: "Coverage",
                table: "AMCContracts",
                newName: "BillingCycle");

            migrationBuilder.AddColumn<Guid>(
              name: "AMCContractId",
              table: "projectMaintenances",
              type: "uniqueidentifier",
              nullable: true);                   

            migrationBuilder.AddColumn<Guid>(
                name: "AMCContractId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChecklistTemplateId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "MaintenanceSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstDueDate",
                table: "MaintenanceSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaintenanceSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MaintenanceSchedules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractType",
                table: "AMCContracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ContractStatus",
                table: "AMCContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            

            migrationBuilder.AddColumn<decimal>(
                name: "ContractValue",
                table: "AMCContracts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceSchedules",
                table: "MaintenanceSchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChecklistTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    LiftAssetType = table.Column<int>(type: "int", nullable: true),
                    FaultCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiftAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiftAssetType = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stops = table.Column<int>(type: "int", nullable: true),
                    CapacityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpeedMps = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HandoverDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiftAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiftAssets_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LiftAssets_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChecklistTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemOrder = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedInputType = table.Column<int>(type: "int", nullable: false),
                    IsCritical = table.Column<bool>(type: "bit", nullable: false),
                    EvidenceRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistItems_ChecklistTemplates_ChecklistTemplateId",
                        column: x => x.ChecklistTemplateId,
                        principalTable: "ChecklistTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AMCContractAssets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMCContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverageEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AMCContractAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AMCContractAssets_AMCContracts_AMCContractId",
                        column: x => x.AMCContractId,
                        principalTable: "AMCContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AMCContractAssets_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AssetComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WarrantyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastReplacementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ComponentStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetComponents_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    FaultCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerTrapped = table.Column<bool>(type: "bit", nullable: false),
                    ReportedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedByPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceTickets_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTickets_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarrantyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyStatus = table.Column<int>(type: "int", nullable: false),
                    TermsSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exclusions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyRecords_AssetComponents_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "AssetComponents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WarrantyRecords_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    CoverageDecision = table.Column<int>(type: "int", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentStatus = table.Column<int>(type: "int", nullable: false),
                    AssignedSupervisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceJobs_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceJobs_MaintenanceSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "MaintenanceSchedules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceJobs_ServiceTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssetStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OldStatus = table.Column<int>(type: "int", nullable: true),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetStatusHistories_LiftAssets_LiftAssetId",
                        column: x => x.LiftAssetId,
                        principalTable: "LiftAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetStatusHistories_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobAssignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleOnJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckInAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAssignments_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobChecklistResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChecklistItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    NumericValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TextValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobChecklistResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobChecklistResponses_ChecklistItems_ChecklistItemId",
                        column: x => x.ChecklistItemId,
                        principalTable: "ChecklistItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobChecklistResponses_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldStatus = table.Column<int>(type: "int", nullable: true),
                    NewStatus = table.Column<int>(type: "int", nullable: false),
                    ChangedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublicNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClientVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobStatusHistories_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePartsRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyClaimId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePartsRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePartsRequests_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceQuotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceQuotes_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenceUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EvidenceType = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClientVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvidenceUploads_JobChecklistResponses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "JobChecklistResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceUploads_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvidenceUploads_ServiceTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "ServiceTickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceInvoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceInvoices_ServiceJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "ServiceJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceInvoices_ServiceQuotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "ServiceQuotes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_projectMaintenances_AMCContractId",
                table: "projectMaintenances",
                column: "AMCContractId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_AMCContractId",
                table: "MaintenanceSchedules",
                column: "AMCContractId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_ChecklistTemplateId",
                table: "MaintenanceSchedules",
                column: "ChecklistTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                column: "ProjectMaintenancesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSchedules_UserId",
                table: "MaintenanceSchedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AMCContracts_ProjectId",
                table: "AMCContracts",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AMCContractAssets_AMCContractId",
                table: "AMCContractAssets",
                column: "AMCContractId");

            migrationBuilder.CreateIndex(
                name: "IX_AMCContractAssets_LiftAssetId",
                table: "AMCContractAssets",
                column: "LiftAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetComponents_LiftAssetId",
                table: "AssetComponents",
                column: "LiftAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStatusHistories_JobId",
                table: "AssetStatusHistories",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetStatusHistories_LiftAssetId",
                table: "AssetStatusHistories",
                column: "LiftAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItems_ChecklistTemplateId",
                table: "ChecklistItems",
                column: "ChecklistTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceUploads_JobId",
                table: "EvidenceUploads",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceUploads_ResponseId",
                table: "EvidenceUploads",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenceUploads_TicketId",
                table: "EvidenceUploads",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_JobId",
                table: "JobAssignments",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAssignments_UserId",
                table: "JobAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChecklistResponses_ChecklistItemId",
                table: "JobChecklistResponses",
                column: "ChecklistItemId");

            migrationBuilder.CreateIndex(
                name: "IX_JobChecklistResponses_JobId",
                table: "JobChecklistResponses",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatusHistories_JobId",
                table: "JobStatusHistories",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftAssets_ClientId",
                table: "LiftAssets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LiftAssets_ProjectId",
                table: "LiftAssets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoices_JobId",
                table: "ServiceInvoices",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoices_QuoteId",
                table: "ServiceInvoices",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceJobs_LiftAssetId",
                table: "ServiceJobs",
                column: "LiftAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceJobs_ScheduleId",
                table: "ServiceJobs",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceJobs_TicketId",
                table: "ServiceJobs",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePartsRequests_JobId",
                table: "ServicePartsRequests",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuotes_JobId",
                table: "ServiceQuotes",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_ClientId",
                table: "ServiceTickets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_LiftAssetId",
                table: "ServiceTickets",
                column: "LiftAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTickets_ProjectId",
                table: "ServiceTickets",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyRecords_ComponentId",
                table: "WarrantyRecords",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyRecords_LiftAssetId",
                table: "WarrantyRecords",
                column: "LiftAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AMCContracts_projects_ProjectId",
                table: "AMCContracts",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_AMCContracts_AMCContractId",
                table: "MaintenanceSchedules",
                column: "AMCContractId",
                principalTable: "AMCContracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_ChecklistTemplates_ChecklistTemplateId",
                table: "MaintenanceSchedules",
                column: "ChecklistTemplateId",
                principalTable: "ChecklistTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_LiftAssets_LiftAssetId",
                table: "MaintenanceSchedules",
                column: "LiftAssetId",
                principalTable: "LiftAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_Users_UserId",
                table: "MaintenanceSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceSchedules_projectMaintenances_ProjectMaintenancesId",
                table: "MaintenanceSchedules",
                column: "ProjectMaintenancesId",
                principalTable: "projectMaintenances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_projectMaintenances_AMCContracts_AMCContractId",
                table: "projectMaintenances",
                column: "AMCContractId",
                principalTable: "AMCContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AMCContracts_projects_ProjectId",
                table: "AMCContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_AMCContracts_AMCContractId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_ChecklistTemplates_ChecklistTemplateId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_LiftAssets_LiftAssetId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_Users_UserId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceSchedules_projectMaintenances_ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_projectMaintenances_AMCContracts_AMCContractId",
                table: "projectMaintenances");

            migrationBuilder.DropTable(
                name: "AMCContractAssets");

            migrationBuilder.DropTable(
                name: "AssetStatusHistories");

            migrationBuilder.DropTable(
                name: "EvidenceUploads");

            migrationBuilder.DropTable(
                name: "JobAssignments");

            migrationBuilder.DropTable(
                name: "JobStatusHistories");

            migrationBuilder.DropTable(
                name: "ServiceInvoices");

            migrationBuilder.DropTable(
                name: "ServicePartsRequests");

            migrationBuilder.DropTable(
                name: "WarrantyRecords");

            migrationBuilder.DropTable(
                name: "JobChecklistResponses");

            migrationBuilder.DropTable(
                name: "ServiceQuotes");

            migrationBuilder.DropTable(
                name: "AssetComponents");

            migrationBuilder.DropTable(
                name: "ChecklistItems");

            migrationBuilder.DropTable(
                name: "ServiceJobs");

            migrationBuilder.DropTable(
                name: "ChecklistTemplates");

            migrationBuilder.DropTable(
                name: "ServiceTickets");

            migrationBuilder.DropTable(
                name: "LiftAssets");

            migrationBuilder.DropIndex(
                name: "IX_projectMaintenances_AMCContractId",
                table: "projectMaintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceSchedules",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_AMCContractId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_ChecklistTemplateId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceSchedules_UserId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropIndex(
                name: "IX_AMCContracts_ProjectId",
                table: "AMCContracts");

            migrationBuilder.DropColumn(
                name: "AMCContractId",
                table: "projectMaintenances");

            migrationBuilder.DropColumn(
                name: "AMCContractId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "ChecklistTemplateId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "FirstDueDate",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "ProjectMaintenancesId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MaintenanceSchedules");

            migrationBuilder.DropColumn(
                name: "ContractStatus",
                table: "AMCContracts");

            migrationBuilder.DropColumn(
                name: "ContractValue",
                table: "AMCContracts");

            migrationBuilder.RenameTable(
                name: "MaintenanceSchedules",
                newName: "maintenanceSchedules");

            migrationBuilder.RenameColumn(
                name: "ScheduleType",
                table: "maintenanceSchedules",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "NextDueDate",
                table: "maintenanceSchedules",
                newName: "ScheduledDate");

            migrationBuilder.RenameColumn(
                name: "LiftAssetId",
                table: "maintenanceSchedules",
                newName: "projectMaintenanceId");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "maintenanceSchedules",
                newName: "Priority");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceSchedules_LiftAssetId",
                table: "maintenanceSchedules",
                newName: "IX_maintenanceSchedules_projectMaintenanceId");

            migrationBuilder.RenameColumn(
                name: "ServiceFrequency",
                table: "AMCContracts",
                newName: "NumberOfPMVisits");

            migrationBuilder.RenameColumn(
                name: "SLAPolicy",
                table: "AMCContracts",
                newName: "SLA");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "AMCContracts",
                newName: "ProjectMaintenanceId");

            migrationBuilder.RenameColumn(
                name: "Inclusions",
                table: "AMCContracts",
                newName: "PaymentSchedule");

            migrationBuilder.RenameColumn(
                name: "Exclusions",
                table: "AMCContracts",
                newName: "IncludedParts");

            migrationBuilder.RenameColumn(
                name: "CurrencyCode",
                table: "AMCContracts",
                newName: "ExcludedParts");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AMCContracts",
                newName: "RenewalReminderDate");

            migrationBuilder.RenameColumn(
                name: "ContractCode",
                table: "AMCContracts",
                newName: "EscalationContacts");

            migrationBuilder.RenameColumn(
                name: "BillingCycle",
                table: "AMCContracts",
                newName: "Coverage");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedTechnician",
                table: "maintenanceSchedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "maintenanceSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ContractType",
                table: "AMCContracts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "AMCContracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_maintenanceSchedules",
                table: "maintenanceSchedules",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_maintenanceSchedules_AssignedTechnician",
                table: "maintenanceSchedules",
                column: "AssignedTechnician");

            migrationBuilder.CreateIndex(
                name: "IX_AMCContracts_ProjectMaintenanceId",
                table: "AMCContracts",
                column: "ProjectMaintenanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AMCContracts_projectMaintenances_ProjectMaintenanceId",
                table: "AMCContracts",
                column: "ProjectMaintenanceId",
                principalTable: "projectMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_maintenanceSchedules_Users_AssignedTechnician",
                table: "maintenanceSchedules",
                column: "AssignedTechnician",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_maintenanceSchedules_projectMaintenances_projectMaintenanceId",
                table: "maintenanceSchedules",
                column: "projectMaintenanceId",
                principalTable: "projectMaintenances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
