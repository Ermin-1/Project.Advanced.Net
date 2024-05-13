using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Advanced.Net.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Samsung" },
                    { 3, "Xiaomi" },
                    { 4, "Google" },
                    { 5, "Microsoft" },
                    { 6, "Amazon" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, "Ermin" },
                    { 2, "Oskar" },
                    { 3, "Sharam" },
                    { 4, "Christian" },
                    { 5, "Lena" },
                    { 6, "Andreas" },
                    { 7, "Emily" },
                    { 8, "David" },
                    { 9, "Sophia" },
                    { 10, "Alexander" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 13, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7368) },
                    { 2, 1, 2, new DateTime(2024, 5, 23, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7418) },
                    { 3, 2, 3, new DateTime(2024, 6, 2, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7430) },
                    { 4, 3, 4, new DateTime(2024, 6, 12, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7462) },
                    { 5, 4, 1, new DateTime(2024, 6, 22, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7472) },
                    { 6, 4, 2, new DateTime(2024, 7, 2, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7483) },
                    { 7, 5, 5, new DateTime(2024, 5, 18, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7493) },
                    { 8, 5, 6, new DateTime(2024, 5, 28, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7503) },
                    { 9, 6, 5, new DateTime(2024, 6, 7, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7513) },
                    { 10, 6, 6, new DateTime(2024, 6, 17, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7524) },
                    { 11, 1, 7, new DateTime(2024, 5, 20, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7533) },
                    { 12, 2, 8, new DateTime(2024, 5, 27, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7543) },
                    { 13, 3, 9, new DateTime(2024, 6, 3, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7552) },
                    { 14, 4, 10, new DateTime(2024, 6, 10, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7563) },
                    { 15, 5, 7, new DateTime(2024, 6, 17, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7572) },
                    { 16, 6, 8, new DateTime(2024, 6, 24, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7582) },
                    { 17, 1, 9, new DateTime(2024, 7, 1, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7591) },
                    { 18, 2, 10, new DateTime(2024, 7, 8, 14, 16, 56, 138, DateTimeKind.Local).AddTicks(7601) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompanyId",
                table: "Appointments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
