using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransactionVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionVehicles",
                columns: table => new
                {
                    TransactionVehicle_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_ID = table.Column<int>(type: "int", nullable: false),
                    Vehicle_ID = table.Column<long>(type: "bigint", nullable: false),
                    EntryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntryVisitor_ID = table.Column<long>(type: "bigint", nullable: false),
                    ExitVisitor_ID = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionVehicles", x => x.TransactionVehicle_ID);
                    table.ForeignKey(
                        name: "FK_TransactionVehicles_Locations_Location_ID",
                        column: x => x.Location_ID,
                        principalTable: "Locations",
                        principalColumn: "Location_ID");
                    table.ForeignKey(
                        name: "FK_TransactionVehicles_Vehicles_Vehicle_ID",
                        column: x => x.Vehicle_ID,
                        principalTable: "Vehicles",
                        principalColumn: "Vehicle_ID");
                    table.ForeignKey(
                        name: "FK_TransactionVehicles_Visitors_EntryVisitor_ID",
                        column: x => x.EntryVisitor_ID,
                        principalTable: "Visitors",
                        principalColumn: "Visitor_ID");
                    table.ForeignKey(
                        name: "FK_TransactionVehicles_Visitors_ExitVisitor_ID",
                        column: x => x.ExitVisitor_ID,
                        principalTable: "Visitors",
                        principalColumn: "Visitor_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVehicles_EntryVisitor_ID",
                table: "TransactionVehicles",
                column: "EntryVisitor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVehicles_ExitVisitor_ID",
                table: "TransactionVehicles",
                column: "ExitVisitor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVehicles_Location_ID",
                table: "TransactionVehicles",
                column: "Location_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionVehicles_Vehicle_ID",
                table: "TransactionVehicles",
                column: "Vehicle_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionVehicles");
        }
    }
}
