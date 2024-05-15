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
                    { 1, 1, 1, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3484) },
                    { 2, 1, 1, new DateTime(2024, 5, 16, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3536) },
                    { 3, 1, 1, new DateTime(2024, 5, 17, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3548) },
                    { 4, 1, 2, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3558) },
                    { 5, 1, 2, new DateTime(2024, 5, 25, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3567) },
                    { 6, 1, 2, new DateTime(2024, 6, 4, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3576) },
                    { 7, 2, 3, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3586) },
                    { 8, 2, 3, new DateTime(2024, 5, 30, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3594) },
                    { 9, 2, 3, new DateTime(2024, 6, 4, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3603) },
                    { 10, 3, 4, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3613) },
                    { 11, 3, 4, new DateTime(2024, 5, 16, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3623) },
                    { 12, 3, 4, new DateTime(2024, 5, 17, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3633) },
                    { 13, 5, 5, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3643) },
                    { 14, 5, 5, new DateTime(2024, 5, 25, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3653) },
                    { 15, 5, 5, new DateTime(2024, 5, 30, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3662) },
                    { 16, 5, 6, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3672) },
                    { 17, 5, 6, new DateTime(2024, 5, 23, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3681) },
                    { 18, 5, 6, new DateTime(2024, 5, 17, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3692) },
                    { 19, 1, 7, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3701) },
                    { 20, 1, 7, new DateTime(2024, 6, 9, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3710) },
                    { 21, 1, 7, new DateTime(2024, 6, 5, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3731) },
                    { 22, 2, 8, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3753) },
                    { 23, 2, 8, new DateTime(2024, 5, 19, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3762) },
                    { 24, 2, 8, new DateTime(2024, 5, 23, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3843) },
                    { 25, 3, 9, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3865) },
                    { 26, 3, 9, new DateTime(2024, 5, 19, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3876) },
                    { 27, 3, 9, new DateTime(2024, 5, 24, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3886) },
                    { 28, 4, 10, new DateTime(2024, 5, 15, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3896) },
                    { 29, 4, 10, new DateTime(2024, 5, 16, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3906) },
                    { 30, 4, 10, new DateTime(2024, 5, 17, 13, 57, 31, 753, DateTimeKind.Local).AddTicks(3915) }
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
