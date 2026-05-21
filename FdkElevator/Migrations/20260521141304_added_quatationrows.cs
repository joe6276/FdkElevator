using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_quatationrows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmcOption",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CustomsCost",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FreightCost",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InstallationCost",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuotationNumber",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SubcontractorCost",
                table: "Quotations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ValidityDays",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmcOption",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CustomsCost",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "FreightCost",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "InstallationCost",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationNumber",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "SubcontractorCost",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ValidityDays",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Quotations");
        }
    }
}
