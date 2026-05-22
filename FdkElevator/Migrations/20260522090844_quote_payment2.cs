using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class quote_payment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotationPayments_Quotations_QuotationId",
                table: "quotationPayments");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuotationId",
                table: "quotationPayments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "quotationPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RevisionId",
                table: "quotationPayments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RevisionId",
                table: "liftConfigurations",
                type: "uniqueidentifier",
                nullable: true);

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
                    QuotationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_revisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_revisions_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_revisions_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_quotationPayments_RevisionId",
                table: "quotationPayments",
                column: "RevisionId");

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
                name: "IX_quoteItemRevisions_revisionId",
                table: "quoteItemRevisions",
                column: "revisionId");

            migrationBuilder.CreateIndex(
                name: "IX_revisions_ClientId",
                table: "revisions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_revisions_LeadId",
                table: "revisions",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_liftConfigurations_revisions_RevisionId",
                table: "liftConfigurations",
                column: "RevisionId",
                principalTable: "revisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotationPayments_Quotations_QuotationId",
                table: "quotationPayments",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotationPayments_revisions_RevisionId",
                table: "quotationPayments",
                column: "RevisionId",
                principalTable: "revisions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_liftConfigurations_revisions_RevisionId",
                table: "liftConfigurations");

            migrationBuilder.DropForeignKey(
                name: "FK_quotationPayments_Quotations_QuotationId",
                table: "quotationPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_quotationPayments_revisions_RevisionId",
                table: "quotationPayments");

            migrationBuilder.DropTable(
                name: "liftConfigurationsRevision");

            migrationBuilder.DropTable(
                name: "quoteItemRevisions");

            migrationBuilder.DropTable(
                name: "revisions");

            migrationBuilder.DropIndex(
                name: "IX_quotationPayments_RevisionId",
                table: "quotationPayments");

            migrationBuilder.DropIndex(
                name: "IX_liftConfigurations_RevisionId",
                table: "liftConfigurations");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "quotationPayments");

            migrationBuilder.DropColumn(
                name: "RevisionId",
                table: "quotationPayments");

            migrationBuilder.DropColumn(
                name: "RevisionId",
                table: "liftConfigurations");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuotationId",
                table: "quotationPayments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quotationPayments_Quotations_QuotationId",
                table: "quotationPayments",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
