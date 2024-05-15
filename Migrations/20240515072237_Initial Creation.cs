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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "CustomerId", "Address", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Campusvägen 7", "Ermin", "Husic", 734141429 },
                    { 2, "Storgatan 10", "Oskar", "Johansson", 723456789 },
                    { 3, "Lilla vägen 3", "Sharam", "Khan", 734567890 },
                    { 4, "Parkgatan 15", "Christian", "Andersson", 765432109 },
                    { 5, "Skolgatan 2", "Lena", "Eriksson", 721567890 },
                    { 6, "Kyrkvägen 6", "Andreas", "Lindström", 709876543 },
                    { 7, "Strandvägen 12", "Emily", "Nilsson", 723456781 },
                    { 8, "Backstugan 4", "David", "Gustafsson", 761234567 },
                    { 9, "Musselvägen 4", "Sophia", "Berg", 723456782 },
                    { 10, "Storgatan 2", "Alexander", "Larsson", 768765432 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 15, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4092) },
                    { 2, 1, 2, new DateTime(2024, 5, 25, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4148) },
                    { 3, 2, 3, new DateTime(2024, 6, 4, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4162) },
                    { 4, 3, 4, new DateTime(2024, 6, 14, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4173) },
                    { 5, 4, 1, new DateTime(2024, 6, 24, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4184) },
                    { 6, 4, 2, new DateTime(2024, 7, 4, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4196) },
                    { 7, 5, 5, new DateTime(2024, 5, 20, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4206) },
                    { 8, 5, 6, new DateTime(2024, 5, 30, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4217) },
                    { 9, 6, 5, new DateTime(2024, 6, 9, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4227) },
                    { 10, 6, 6, new DateTime(2024, 6, 19, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4264) },
                    { 11, 1, 7, new DateTime(2024, 5, 22, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4275) },
                    { 12, 2, 8, new DateTime(2024, 5, 29, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4286) },
                    { 13, 3, 9, new DateTime(2024, 6, 5, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4297) },
                    { 14, 4, 10, new DateTime(2024, 6, 12, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4308) },
                    { 15, 5, 7, new DateTime(2024, 6, 19, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4319) },
                    { 16, 6, 8, new DateTime(2024, 6, 26, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4330) },
                    { 17, 1, 9, new DateTime(2024, 7, 3, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4340) },
                    { 18, 2, 10, new DateTime(2024, 7, 10, 9, 22, 37, 51, DateTimeKind.Local).AddTicks(4354) }
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
