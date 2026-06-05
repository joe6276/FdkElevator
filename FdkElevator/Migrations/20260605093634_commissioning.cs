using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class commissioning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommissionedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Users_CommissionedBy",
                        column: x => x.CommissionedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ClientTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attendees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingTopics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyRescueBasics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingPrecautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentReceived = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTrainings_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "functionalTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallButtons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandingIndicators = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CabinOperatingPanel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorOpening = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorClosing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deceleration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acceleration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorLevelling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RescueOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiremanOperation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARDBehaviour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPSBehaviour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerFailureResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_functionalTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_functionalTests_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "generatedDocumentsCertificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_generatedDocumentsCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_generatedDocumentsCertificates_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "punchLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_punchLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_punchLists_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyChecks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmergencyStop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorLocks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alarm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intercom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverloadProtection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverspeedGovernor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyGear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buffers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimitSwitches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrakeFunction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevellingAccuracy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phaseprotection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grounding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerFaultHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyChecks_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CeritificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneratedDocumentsCertificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_certificates_Users_IssuedBy",
                        column: x => x.IssuedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_certificates_generatedDocumentsCertificates_GeneratedDocumentsCertificateId",
                        column: x => x.GeneratedDocumentsCertificateId,
                        principalTable: "generatedDocumentsCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Punch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PunchDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectionRequired = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibleParty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    PunchListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punch_punchLists_PunchListId",
                        column: x => x.PunchListId,
                        principalTable: "punchLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_certificates_GeneratedDocumentsCertificateId",
                table: "certificates",
                column: "GeneratedDocumentsCertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_certificates_IssuedBy",
                table: "certificates",
                column: "IssuedBy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrainings_CommissionId",
                table: "ClientTrainings",
                column: "CommissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CommissionedBy",
                table: "Commissions",
                column: "CommissionedBy",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ProjectId",
                table: "Commissions",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_functionalTests_CommissionId",
                table: "functionalTests",
                column: "CommissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_generatedDocumentsCertificates_CommissionId",
                table: "generatedDocumentsCertificates",
                column: "CommissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Punch_PunchListId",
                table: "Punch",
                column: "PunchListId");

            migrationBuilder.CreateIndex(
                name: "IX_punchLists_CommissionId",
                table: "punchLists",
                column: "CommissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SafetyChecks_CommissionId",
                table: "SafetyChecks",
                column: "CommissionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "ClientTrainings");

            migrationBuilder.DropTable(
                name: "functionalTests");

            migrationBuilder.DropTable(
                name: "Punch");

            migrationBuilder.DropTable(
                name: "SafetyChecks");

            migrationBuilder.DropTable(
                name: "generatedDocumentsCertificates");

            migrationBuilder.DropTable(
                name: "punchLists");

            migrationBuilder.DropTable(
                name: "Commissions");
        }
    }
}
