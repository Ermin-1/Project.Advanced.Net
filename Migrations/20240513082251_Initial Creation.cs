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
                    { 1, 1, 1, new DateTime(2024, 5, 13, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4100) },
                    { 2, 1, 2, new DateTime(2024, 5, 23, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4157) },
                    { 3, 2, 3, new DateTime(2024, 6, 2, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4170) },
                    { 4, 3, 4, new DateTime(2024, 6, 12, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4210) },
                    { 5, 4, 1, new DateTime(2024, 6, 22, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4224) },
                    { 6, 4, 2, new DateTime(2024, 7, 2, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4236) },
                    { 7, 5, 5, new DateTime(2024, 5, 18, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4260) },
                    { 8, 5, 6, new DateTime(2024, 5, 28, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4271) },
                    { 9, 6, 5, new DateTime(2024, 6, 7, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4282) },
                    { 10, 6, 6, new DateTime(2024, 6, 17, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4293) },
                    { 11, 1, 7, new DateTime(2024, 5, 20, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4304) },
                    { 12, 2, 8, new DateTime(2024, 5, 27, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4316) },
                    { 13, 3, 9, new DateTime(2024, 6, 3, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4326) },
                    { 14, 4, 10, new DateTime(2024, 6, 10, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4336) },
                    { 15, 5, 7, new DateTime(2024, 6, 17, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4347) },
                    { 16, 6, 8, new DateTime(2024, 6, 24, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4357) },
                    { 17, 1, 9, new DateTime(2024, 7, 1, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4368) },
                    { 18, 2, 10, new DateTime(2024, 7, 8, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4379) }
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
