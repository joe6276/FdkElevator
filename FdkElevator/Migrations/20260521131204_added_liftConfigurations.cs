using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FdkElevator.Migrations
{
    /// <inheritdoc />
    public partial class added_liftConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
   

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
                    QuotationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_liftConfigurations_QuotationId",
                table: "liftConfigurations",
                column: "QuotationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "liftConfigurations");

            
        }
    }
}
