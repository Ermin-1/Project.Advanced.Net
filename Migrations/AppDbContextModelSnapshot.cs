﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt___Avancerad_.NET.Data;

#nullable disable

namespace Project.Advanced.Net.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectModels.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentId = 1,
                            CompanyId = 1,
                            CustomerId = 1,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(848)
                        },
                        new
                        {
                            AppointmentId = 2,
                            CompanyId = 1,
                            CustomerId = 1,
                            Time = new DateTime(2024, 5, 23, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(907)
                        },
                        new
                        {
                            AppointmentId = 3,
                            CompanyId = 1,
                            CustomerId = 1,
                            Time = new DateTime(2024, 5, 24, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(921)
                        },
                        new
                        {
                            AppointmentId = 4,
                            CompanyId = 1,
                            CustomerId = 2,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(933)
                        },
                        new
                        {
                            AppointmentId = 5,
                            CompanyId = 1,
                            CustomerId = 2,
                            Time = new DateTime(2024, 6, 1, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(945)
                        },
                        new
                        {
                            AppointmentId = 6,
                            CompanyId = 1,
                            CustomerId = 2,
                            Time = new DateTime(2024, 6, 11, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(959)
                        },
                        new
                        {
                            AppointmentId = 7,
                            CompanyId = 2,
                            CustomerId = 3,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(993)
                        },
                        new
                        {
                            AppointmentId = 8,
                            CompanyId = 2,
                            CustomerId = 3,
                            Time = new DateTime(2024, 6, 6, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1005)
                        },
                        new
                        {
                            AppointmentId = 9,
                            CompanyId = 2,
                            CustomerId = 3,
                            Time = new DateTime(2024, 6, 11, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1018)
                        },
                        new
                        {
                            AppointmentId = 10,
                            CompanyId = 3,
                            CustomerId = 4,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1032)
                        },
                        new
                        {
                            AppointmentId = 11,
                            CompanyId = 3,
                            CustomerId = 4,
                            Time = new DateTime(2024, 5, 23, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1044)
                        },
                        new
                        {
                            AppointmentId = 12,
                            CompanyId = 3,
                            CustomerId = 4,
                            Time = new DateTime(2024, 5, 24, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1056)
                        },
                        new
                        {
                            AppointmentId = 13,
                            CompanyId = 5,
                            CustomerId = 5,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1068)
                        },
                        new
                        {
                            AppointmentId = 14,
                            CompanyId = 5,
                            CustomerId = 5,
                            Time = new DateTime(2024, 6, 1, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1080)
                        },
                        new
                        {
                            AppointmentId = 15,
                            CompanyId = 5,
                            CustomerId = 5,
                            Time = new DateTime(2024, 6, 6, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1092)
                        },
                        new
                        {
                            AppointmentId = 16,
                            CompanyId = 5,
                            CustomerId = 6,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1103)
                        },
                        new
                        {
                            AppointmentId = 17,
                            CompanyId = 5,
                            CustomerId = 6,
                            Time = new DateTime(2024, 5, 30, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1115)
                        },
                        new
                        {
                            AppointmentId = 18,
                            CompanyId = 5,
                            CustomerId = 6,
                            Time = new DateTime(2024, 5, 24, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1128)
                        },
                        new
                        {
                            AppointmentId = 19,
                            CompanyId = 1,
                            CustomerId = 7,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1140)
                        },
                        new
                        {
                            AppointmentId = 20,
                            CompanyId = 1,
                            CustomerId = 7,
                            Time = new DateTime(2024, 6, 16, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1152)
                        },
                        new
                        {
                            AppointmentId = 21,
                            CompanyId = 1,
                            CustomerId = 7,
                            Time = new DateTime(2024, 6, 12, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1164)
                        },
                        new
                        {
                            AppointmentId = 22,
                            CompanyId = 2,
                            CustomerId = 8,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1176)
                        },
                        new
                        {
                            AppointmentId = 23,
                            CompanyId = 2,
                            CustomerId = 8,
                            Time = new DateTime(2024, 5, 26, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1187)
                        },
                        new
                        {
                            AppointmentId = 24,
                            CompanyId = 2,
                            CustomerId = 8,
                            Time = new DateTime(2024, 5, 30, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1198)
                        },
                        new
                        {
                            AppointmentId = 25,
                            CompanyId = 3,
                            CustomerId = 9,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1209)
                        },
                        new
                        {
                            AppointmentId = 26,
                            CompanyId = 3,
                            CustomerId = 9,
                            Time = new DateTime(2024, 5, 26, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1247)
                        },
                        new
                        {
                            AppointmentId = 27,
                            CompanyId = 3,
                            CustomerId = 9,
                            Time = new DateTime(2024, 5, 31, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1257)
                        },
                        new
                        {
                            AppointmentId = 28,
                            CompanyId = 4,
                            CustomerId = 10,
                            Time = new DateTime(2024, 5, 22, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1269)
                        },
                        new
                        {
                            AppointmentId = 29,
                            CompanyId = 4,
                            CustomerId = 10,
                            Time = new DateTime(2024, 5, 23, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1281)
                        },
                        new
                        {
                            AppointmentId = 30,
                            CompanyId = 4,
                            CustomerId = 10,
                            Time = new DateTime(2024, 5, 24, 7, 48, 49, 954, DateTimeKind.Local).AddTicks(1291)
                        });
                });

            modelBuilder.Entity("ProjectModels.AppointmentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Changes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.ToTable("AppointmentHistories");
                });

            modelBuilder.Entity("ProjectModels.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Name = "Apple"
                        },
                        new
                        {
                            CompanyId = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            CompanyId = 3,
                            Name = "Xiaomi"
                        },
                        new
                        {
                            CompanyId = 4,
                            Name = "Google"
                        },
                        new
                        {
                            CompanyId = 5,
                            Name = "Microsoft"
                        },
                        new
                        {
                            CompanyId = 6,
                            Name = "Amazon"
                        });
                });

            modelBuilder.Entity("ProjectModels.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "Campusvägen 7",
                            Email = "ermin.husic@example.com",
                            FirstName = "Ermin",
                            LastName = "Husic",
                            PhoneNumber = 734141429
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "Storgatan 10",
                            Email = "oskar.johansson@example.com",
                            FirstName = "Oskar",
                            LastName = "Johansson",
                            PhoneNumber = 723456789
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "Lilla vägen 3",
                            Email = "sharam.khan@example.com",
                            FirstName = "Sharam",
                            LastName = "Khan",
                            PhoneNumber = 734567890
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "Parkgatan 15",
                            Email = "christian.andersson@example.com",
                            FirstName = "Christian",
                            LastName = "Andersson",
                            PhoneNumber = 765432109
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "Skolgatan 2",
                            Email = "lena.eriksson@example.com",
                            FirstName = "Lena",
                            LastName = "Eriksson",
                            PhoneNumber = 721567890
                        },
                        new
                        {
                            CustomerId = 6,
                            Address = "Kyrkvägen 6",
                            Email = "andreas.lindstrom@example.com",
                            FirstName = "Andreas",
                            LastName = "Lindström",
                            PhoneNumber = 709876543
                        },
                        new
                        {
                            CustomerId = 7,
                            Address = "Strandvägen 12",
                            Email = "emily.nilsson@example.com",
                            FirstName = "Emily",
                            LastName = "Nilsson",
                            PhoneNumber = 723456781
                        },
                        new
                        {
                            CustomerId = 8,
                            Address = "Backstugan 4",
                            Email = "david.gustafsson@example.com",
                            FirstName = "David",
                            LastName = "Gustafsson",
                            PhoneNumber = 761234567
                        },
                        new
                        {
                            CustomerId = 9,
                            Address = "Musselvägen 4",
                            Email = "sophia.berg@example.com",
                            FirstName = "Sophia",
                            LastName = "Berg",
                            PhoneNumber = 723456782
                        },
                        new
                        {
                            CustomerId = 10,
                            Address = "Storgatan 2",
                            Email = "alexander.larsson@example.com",
                            FirstName = "Alexander",
                            LastName = "Larsson",
                            PhoneNumber = 768765432
                        });
                });

            modelBuilder.Entity("ProjectModels.LoginInfo", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("LoginInfos");

                    b.HasData(
                        new
                        {
                            LoginId = 1,
                            CustomerId = 1,
                            EMail = "ermin.husic@example.com",
                            Password = "password1",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 2,
                            CustomerId = 2,
                            EMail = "oskar.johansson@example.com",
                            Password = "password2",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 3,
                            CustomerId = 3,
                            EMail = "sharam.khan@example.com",
                            Password = "password3",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 4,
                            CustomerId = 4,
                            EMail = "christian.andersson@example.com",
                            Password = "password4",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 5,
                            CustomerId = 5,
                            EMail = "lena.eriksson@example.com",
                            Password = "password5",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 6,
                            CustomerId = 6,
                            EMail = "andreas.lindstrom@example.com",
                            Password = "password6",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 7,
                            CustomerId = 7,
                            EMail = "emily.nilsson@example.com",
                            Password = "password7",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 8,
                            CustomerId = 8,
                            EMail = "david.gustafsson@example.com",
                            Password = "password8",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 9,
                            CustomerId = 9,
                            EMail = "sophia.berg@example.com",
                            Password = "password9",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 10,
                            CustomerId = 10,
                            EMail = "alexander.larsson@example.com",
                            Password = "password10",
                            Role = "customer"
                        },
                        new
                        {
                            LoginId = 11,
                            EMail = "admin@admin.se",
                            Password = "1234",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 17,
                            CompanyId = 1,
                            EMail = "admin@apple.com",
                            Password = "password1",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 12,
                            CompanyId = 2,
                            EMail = "admin@samsung.com",
                            Password = "password2",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 13,
                            CompanyId = 3,
                            EMail = "admin@xiaomi.com",
                            Password = "password3",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 14,
                            CompanyId = 4,
                            EMail = "admin@google.com",
                            Password = "password4",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 15,
                            CompanyId = 5,
                            EMail = "admin@microsoft.com",
                            Password = "password5",
                            Role = "admin"
                        },
                        new
                        {
                            LoginId = 16,
                            CompanyId = 6,
                            EMail = "admin@amazon.com",
                            Password = "password6",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("ProjectModels.Appointment", b =>
                {
                    b.HasOne("ProjectModels.Company", "Company")
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectModels.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProjectModels.AppointmentHistory", b =>
                {
                    b.HasOne("ProjectModels.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("ProjectModels.LoginInfo", b =>
                {
                    b.HasOne("ProjectModels.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("ProjectModels.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Company");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProjectModels.Company", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ProjectModels.Customer", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
