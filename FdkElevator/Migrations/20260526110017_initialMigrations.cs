using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreePlanCost = table.Column<float>(type: "real", nullable: false),
                    BasicPlanCost = table.Column<float>(type: "real", nullable: false),
                    PremiumPlanCost = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordResetExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subscription_Plan = table.Column<int>(type: "int", nullable: true),
                    Subscription_Status = table.Column<int>(type: "int", nullable: true),
                    SubscriptionExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "supplierItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supplierItems_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StripePaymentIntent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantSubs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordResetExpires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstTimeLogin = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientCategory = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    source = table.Column<int>(type: "int", nullable: false),
                    leadType = table.Column<int>(type: "int", nullable: false),
                    urgency = table.Column<int>(type: "int", nullable: false),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    decisionMaker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForLoss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberofFloors = table.Column<int>(type: "int", nullable: false),
                    NumberofElevators = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    leadStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leads_Users_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AllSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllSurveys_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllSurveys_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AllSurveys_Users_SurveyorId",
                        column: x => x.SurveyorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QuotationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    InstallationCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreightCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubcontractorCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmcOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidityDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "projectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectTasks_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectTeams_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectTeams_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteChallenges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyorRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalNotes_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntranceDoorDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfEntrances = table.Column<int>(type: "int", nullable: false),
                    DoorOpeningType = table.Column<int>(type: "int", nullable: false),
                    DoorSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingDoorFinishPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntranceDoorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntranceDoorDetails_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinishingDesignPreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CabinFinishPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlooringPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CeilingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MirrorRequired = table.Column<bool>(type: "bit", nullable: false),
                    HandrailsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayTypePreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishingDesignPreferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinishingDesignPreferences_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaintenanceContractRequired = table.Column<bool>(type: "bit", nullable: false),
                    ExistingLiftOnSite = table.Column<bool>(type: "bit", nullable: false),
                    CurrentLiftCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceFrequencyPreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerElectricalInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PowerSupplyAvailable = table.Column<int>(type: "int", nullable: false),
                    VoltageAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackupGeneratorAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DedicatedLiftPowerLineAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerElectricalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerElectricalInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    LiftTypeRequired = table.Column<int>(type: "int", nullable: false),
                    NumberOfLiftsRequired = table.Column<int>(type: "int", nullable: false),
                    ExpectedCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStopsFloors = table.Column<int>(type: "int", nullable: false),
                    TravelHeightMeters = table.Column<double>(type: "float", nullable: false),
                    EstimatedCompletionTimeline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyComplianceInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiremanOperationRequired = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyRescueSystemRequired = table.Column<bool>(type: "bit", nullable: false),
                    CctvRequired = table.Column<bool>(type: "bit", nullable: false),
                    AccessControlRequired = table.Column<bool>(type: "bit", nullable: false),
                    ComplianceStandardRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyComplianceInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyComplianceInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShaftStructuralInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShaftType = table.Column<int>(type: "int", nullable: false),
                    ShaftLocation = table.Column<int>(type: "int", nullable: false),
                    CoreCuttingRequired = table.Column<bool>(type: "bit", nullable: false),
                    ShaftSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShaftHeight = table.Column<double>(type: "float", nullable: false),
                    PitDepth = table.Column<double>(type: "float", nullable: false),
                    OverheadHeightHeadroom = table.Column<double>(type: "float", nullable: false),
                    MachineRoomAvailability = table.Column<bool>(type: "bit", nullable: false),
                    MachineRoomLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StructuralDrawingsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CivilWorksRequired = table.Column<bool>(type: "bit", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaftStructuralInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaftStructuralInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteMediaAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteAttachments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteMediaAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteMediaAttachments_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsageTrafficInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingUsage = table.Column<int>(type: "int", nullable: false),
                    EstimatedDailyTraffic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PeakUsageHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessibilityRequirements = table.Column<int>(type: "int", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageTrafficInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsageTrafficInfos_AllSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "AllSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuoteItems_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "revisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RevisionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstallationCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FreightCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomsCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubcontractorCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmcOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidityDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_revisions_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_revisions_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_revisions_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "liftConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stops = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinFinish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liftConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_liftConfigurations_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_liftConfigurations_revisions_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "revisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "liftConfigurationsRevision",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stops = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinFinish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liftConfigurationsRevision", x => x.Id);
                    table.ForeignKey(
                        name: "FK_liftConfigurationsRevision_revisions_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "revisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quotationPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RevisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotationPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quotationPayments_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_quotationPayments_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quotationPayments_revisions_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "revisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "quoteItemRevisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    revisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quoteItemRevisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quoteItemRevisions_revisions_revisionId",
                        column: x => x.revisionId,
                        principalTable: "revisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LeadId",
                table: "Activities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TenantId",
                table: "Activities",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalNotes_SurveyId",
                table: "AdditionalNotes",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllSurveys_LeadId",
                table: "AllSurveys",
                column: "LeadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllSurveys_SurveyorId",
                table: "AllSurveys",
                column: "SurveyorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllSurveys_TenantId",
                table: "AllSurveys",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_EntranceDoorDetails_SurveyId",
                table: "EntranceDoorDetails",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinishingDesignPreferences_SurveyId",
                table: "FinishingDesignPreferences",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SalesPersonId",
                table: "Leads",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_TenantId",
                table: "Leads",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_liftConfigurations_QuotationId",
                table: "liftConfigurations",
                column: "QuotationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_liftConfigurations_RevisionId",
                table: "liftConfigurations",
                column: "RevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_liftConfigurationsRevision_RevisionId",
                table: "liftConfigurationsRevision",
                column: "RevisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceInfos_SurveyId",
                table: "MaintenanceServiceInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerElectricalInfos_SurveyId",
                table: "PowerElectricalInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projectInfos_SurveyId",
                table: "projectInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_ClientId",
                table: "projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTasks_ProjectId",
                table: "projectTasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_ProjectId",
                table: "projectTeams",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_UserId",
                table: "projectTeams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_quotationPayments_ClientId",
                table: "quotationPayments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_quotationPayments_QuotationId",
                table: "quotationPayments",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_quotationPayments_RevisionId",
                table: "quotationPayments",
                column: "RevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientId",
                table: "Quotations",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_LeadId",
                table: "Quotations",
                column: "LeadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_quoteItemRevisions_revisionId",
                table: "quoteItemRevisions",
                column: "revisionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_QuotationId",
                table: "QuoteItems",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_revisions_ClientId",
                table: "revisions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_revisions_LeadId",
                table: "revisions",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_revisions_QuotationId",
                table: "revisions",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyComplianceInfos_SurveyId",
                table: "SafetyComplianceInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShaftStructuralInfos_SurveyId",
                table: "ShaftStructuralInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteMediaAttachments_SurveyId",
                table: "SiteMediaAttachments",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_supplierItems_SupplierId",
                table: "supplierItems",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantId",
                table: "Tenants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSubs_TenantId",
                table: "TenantSubs",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsageTrafficInfos_SurveyId",
                table: "UsageTrafficInfos",
                column: "SurveyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AdditionalNotes");

            migrationBuilder.DropTable(
                name: "EntranceDoorDetails");

            migrationBuilder.DropTable(
                name: "FinishingDesignPreferences");

            migrationBuilder.DropTable(
                name: "liftConfigurations");

            migrationBuilder.DropTable(
                name: "liftConfigurationsRevision");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceInfos");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PowerElectricalInfos");

            migrationBuilder.DropTable(
                name: "projectInfos");

            migrationBuilder.DropTable(
                name: "projectTasks");

            migrationBuilder.DropTable(
                name: "projectTeams");

            migrationBuilder.DropTable(
                name: "quotationPayments");

            migrationBuilder.DropTable(
                name: "quoteItemRevisions");

            migrationBuilder.DropTable(
                name: "QuoteItems");

            migrationBuilder.DropTable(
                name: "SafetyComplianceInfos");

            migrationBuilder.DropTable(
                name: "ShaftStructuralInfos");

            migrationBuilder.DropTable(
                name: "SiteMediaAttachments");

            migrationBuilder.DropTable(
                name: "supplierItems");

            migrationBuilder.DropTable(
                name: "TenantSubs");

            migrationBuilder.DropTable(
                name: "UsageTrafficInfos");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "revisions");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "AllSurveys");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
