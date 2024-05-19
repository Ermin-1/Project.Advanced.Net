using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Advanced.Net.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
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

            migrationBuilder.CreateTable(
                name: "AppointmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Changes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentHistories_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
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
                    { 1, 1, 1, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8697) },
                    { 2, 1, 1, new DateTime(2024, 5, 18, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8747) },
                    { 3, 1, 1, new DateTime(2024, 5, 19, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8758) },
                    { 4, 1, 2, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8767) },
                    { 5, 1, 2, new DateTime(2024, 5, 27, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8776) },
                    { 6, 1, 2, new DateTime(2024, 6, 6, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8786) },
                    { 7, 2, 3, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8795) },
                    { 8, 2, 3, new DateTime(2024, 6, 1, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8803) },
                    { 9, 2, 3, new DateTime(2024, 6, 6, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8812) },
                    { 10, 3, 4, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8822) },
                    { 11, 3, 4, new DateTime(2024, 5, 18, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8831) },
                    { 12, 3, 4, new DateTime(2024, 5, 19, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8860) },
                    { 13, 5, 5, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8872) },
                    { 14, 5, 5, new DateTime(2024, 5, 27, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8881) },
                    { 15, 5, 5, new DateTime(2024, 6, 1, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8890) },
                    { 16, 5, 6, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8900) },
                    { 17, 5, 6, new DateTime(2024, 5, 25, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8909) },
                    { 18, 5, 6, new DateTime(2024, 5, 19, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8919) },
                    { 19, 1, 7, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8929) },
                    { 20, 1, 7, new DateTime(2024, 6, 11, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8939) },
                    { 21, 1, 7, new DateTime(2024, 6, 7, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8949) },
                    { 22, 2, 8, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8958) },
                    { 23, 2, 8, new DateTime(2024, 5, 21, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8967) },
                    { 24, 2, 8, new DateTime(2024, 5, 25, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8976) },
                    { 25, 3, 9, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8985) },
                    { 26, 3, 9, new DateTime(2024, 5, 21, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(8994) },
                    { 27, 3, 9, new DateTime(2024, 5, 26, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(9003) },
                    { 28, 4, 10, new DateTime(2024, 5, 17, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(9012) },
                    { 29, 4, 10, new DateTime(2024, 5, 18, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(9022) },
                    { 30, 4, 10, new DateTime(2024, 5, 19, 11, 2, 2, 83, DateTimeKind.Local).AddTicks(9030) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistories_AppointmentId",
                table: "AppointmentHistories",
                column: "AppointmentId");

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
                name: "AppointmentHistories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
