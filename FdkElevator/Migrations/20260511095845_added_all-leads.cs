using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_allleads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lead_Tenants_TenantId",
                table: "Lead");

            migrationBuilder.DropForeignKey(
                name: "FK_Lead_Users_SalesPersonId",
                table: "Lead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lead",
                table: "Lead");

            migrationBuilder.RenameTable(
                name: "Lead",
                newName: "Leads");

            migrationBuilder.RenameIndex(
                name: "IX_Lead_TenantId",
                table: "Leads",
                newName: "IX_Leads_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Lead_SalesPersonId",
                table: "Leads",
                newName: "IX_Leads_SalesPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leads",
                table: "Leads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Tenants_TenantId",
                table: "Leads",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Users_SalesPersonId",
                table: "Leads",
                column: "SalesPersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Tenants_TenantId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Users_SalesPersonId",
                table: "Leads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leads",
                table: "Leads");

            migrationBuilder.RenameTable(
                name: "Leads",
                newName: "Lead");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_TenantId",
                table: "Lead",
                newName: "IX_Lead_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Leads_SalesPersonId",
                table: "Lead",
                newName: "IX_Lead_SalesPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lead",
                table: "Lead",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_Tenants_TenantId",
                table: "Lead",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Lead_Users_SalesPersonId",
                table: "Lead",
                column: "SalesPersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
