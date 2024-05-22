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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfos", x => x.Id);
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
                columns: new[] { "CompanyId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "admin@apple.com", "Apple" },
                    { 2, "admin@samsung.com", "Samsung" },
                    { 3, "admin@xiaomi.com", "Xiaomi" },
                    { 4, "admin@google.com", "Google" },
                    { 5, "admin@microsoft.com", "Microsoft" },
                    { 6, "admin@amazon.com", "Amazon" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Campusvägen 7", "ermin.husic@example.com", "Ermin", "Husic", 734141429 },
                    { 2, "Storgatan 10", "oskar.johansson@example.com", "Oskar", "Johansson", 723456789 },
                    { 3, "Lilla vägen 3", "sharam.khan@example.com", "Sharam", "Khan", 734567890 },
                    { 4, "Parkgatan 15", "christian.andersson@example.com", "Christian", "Andersson", 765432109 },
                    { 5, "Skolgatan 2", "lena.eriksson@example.com", "Lena", "Eriksson", 721567890 },
                    { 6, "Kyrkvägen 6", "andreas.lindstrom@example.com", "Andreas", "Lindström", 709876543 },
                    { 7, "Strandvägen 12", "emily.nilsson@example.com", "Emily", "Nilsson", 723456781 },
                    { 8, "Backstugan 4", "david.gustafsson@example.com", "David", "Gustafsson", 761234567 },
                    { 9, "Musselvägen 4", "sophia.berg@example.com", "Sophia", "Berg", 723456782 },
                    { 10, "Storgatan 2", "alexander.larsson@example.com", "Alexander", "Larsson", 768765432 }
                });

            migrationBuilder.InsertData(
                table: "LoginInfos",
                columns: new[] { "Id", "CompanyId", "CustomerId", "EMail", "Password", "Role" },
                values: new object[,]
                {
                    { 1, 0, 1, "ermin.husic@example.com", "password1", "customer" },
                    { 2, 0, 2, "oskar.johansson@example.com", "password2", "customer" },
                    { 3, 0, 3, "sharam.khan@example.com", "password3", "customer" },
                    { 4, 0, 4, "christian.andersson@example.com", "password4", "customer" },
                    { 5, 0, 5, "lena.eriksson@example.com", "password5", "customer" },
                    { 6, 0, 6, "andreas.lindstrom@example.com", "password6", "customer" },
                    { 7, 0, 7, "emily.nilsson@example.com", "password7", "customer" },
                    { 8, 0, 8, "david.gustafsson@example.com", "password8", "customer" },
                    { 9, 0, 9, "sophia.berg@example.com", "password9", "customer" },
                    { 10, 0, 10, "alexander.larsson@example.com", "password10", "customer" },
                    { 11, 0, 0, "admin@admin.se", "1234", "admin" },
                    { 12, 2, 0, "admin@samsung.com", "password2", "company" },
                    { 13, 3, 0, "admin@xiaomi.com", "password3", "company" },
                    { 14, 4, 0, "admin@google.com", "password4", "company" },
                    { 15, 5, 0, "admin@microsoft.com", "password5", "company" },
                    { 16, 6, 0, "admin@amazon.com", "password6", "company" },
                    { 17, 1, 0, "admin@apple.com", "password1", "company" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "CompanyId", "CustomerId", "Time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4833) },
                    { 2, 1, 1, new DateTime(2024, 5, 23, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4892) },
                    { 3, 1, 1, new DateTime(2024, 5, 24, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4906) },
                    { 4, 1, 2, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4917) },
                    { 5, 1, 2, new DateTime(2024, 6, 1, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4927) },
                    { 6, 1, 2, new DateTime(2024, 6, 11, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4938) },
                    { 7, 2, 3, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4949) },
                    { 8, 2, 3, new DateTime(2024, 6, 6, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4960) },
                    { 9, 2, 3, new DateTime(2024, 6, 11, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4971) },
                    { 10, 3, 4, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4981) },
                    { 11, 3, 4, new DateTime(2024, 5, 23, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(4992) },
                    { 12, 3, 4, new DateTime(2024, 5, 24, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5002) },
                    { 13, 5, 5, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5012) },
                    { 14, 5, 5, new DateTime(2024, 6, 1, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5023) },
                    { 15, 5, 5, new DateTime(2024, 6, 6, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5033) },
                    { 16, 5, 6, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5043) },
                    { 17, 5, 6, new DateTime(2024, 5, 30, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5054) },
                    { 18, 5, 6, new DateTime(2024, 5, 24, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5065) },
                    { 19, 1, 7, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5075) },
                    { 20, 1, 7, new DateTime(2024, 6, 16, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5086) },
                    { 21, 1, 7, new DateTime(2024, 6, 12, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5096) },
                    { 22, 2, 8, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5106) },
                    { 23, 2, 8, new DateTime(2024, 5, 26, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5117) },
                    { 24, 2, 8, new DateTime(2024, 5, 30, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5128) },
                    { 25, 3, 9, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5139) },
                    { 26, 3, 9, new DateTime(2024, 5, 26, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5169) },
                    { 27, 3, 9, new DateTime(2024, 5, 31, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5179) },
                    { 28, 4, 10, new DateTime(2024, 5, 22, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5235) },
                    { 29, 4, 10, new DateTime(2024, 5, 23, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5247) },
                    { 30, 4, 10, new DateTime(2024, 5, 24, 14, 17, 52, 406, DateTimeKind.Local).AddTicks(5258) }
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
                name: "LoginInfos");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
