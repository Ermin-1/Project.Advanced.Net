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
                            Time = new DateTime(2024, 5, 13, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4100)
                        },
                        new
                        {
                            AppointmentId = 2,
                            CompanyId = 1,
                            CustomerId = 2,
                            Time = new DateTime(2024, 5, 23, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4157)
                        },
                        new
                        {
                            AppointmentId = 3,
                            CompanyId = 2,
                            CustomerId = 3,
                            Time = new DateTime(2024, 6, 2, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4170)
                        },
                        new
                        {
                            AppointmentId = 4,
                            CompanyId = 3,
                            CustomerId = 4,
                            Time = new DateTime(2024, 6, 12, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4210)
                        },
                        new
                        {
                            AppointmentId = 5,
                            CompanyId = 4,
                            CustomerId = 1,
                            Time = new DateTime(2024, 6, 22, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4224)
                        },
                        new
                        {
                            AppointmentId = 6,
                            CompanyId = 4,
                            CustomerId = 2,
                            Time = new DateTime(2024, 7, 2, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4236)
                        },
                        new
                        {
                            AppointmentId = 7,
                            CompanyId = 5,
                            CustomerId = 5,
                            Time = new DateTime(2024, 5, 18, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4260)
                        },
                        new
                        {
                            AppointmentId = 8,
                            CompanyId = 5,
                            CustomerId = 6,
                            Time = new DateTime(2024, 5, 28, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4271)
                        },
                        new
                        {
                            AppointmentId = 9,
                            CompanyId = 6,
                            CustomerId = 5,
                            Time = new DateTime(2024, 6, 7, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4282)
                        },
                        new
                        {
                            AppointmentId = 10,
                            CompanyId = 6,
                            CustomerId = 6,
                            Time = new DateTime(2024, 6, 17, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4293)
                        },
                        new
                        {
                            AppointmentId = 11,
                            CompanyId = 1,
                            CustomerId = 7,
                            Time = new DateTime(2024, 5, 20, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4304)
                        },
                        new
                        {
                            AppointmentId = 12,
                            CompanyId = 2,
                            CustomerId = 8,
                            Time = new DateTime(2024, 5, 27, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4316)
                        },
                        new
                        {
                            AppointmentId = 13,
                            CompanyId = 3,
                            CustomerId = 9,
                            Time = new DateTime(2024, 6, 3, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4326)
                        },
                        new
                        {
                            AppointmentId = 14,
                            CompanyId = 4,
                            CustomerId = 10,
                            Time = new DateTime(2024, 6, 10, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4336)
                        },
                        new
                        {
                            AppointmentId = 15,
                            CompanyId = 5,
                            CustomerId = 7,
                            Time = new DateTime(2024, 6, 17, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4347)
                        },
                        new
                        {
                            AppointmentId = 16,
                            CompanyId = 6,
                            CustomerId = 8,
                            Time = new DateTime(2024, 6, 24, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4357)
                        },
                        new
                        {
                            AppointmentId = 17,
                            CompanyId = 1,
                            CustomerId = 9,
                            Time = new DateTime(2024, 7, 1, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4368)
                        },
                        new
                        {
                            AppointmentId = 18,
                            CompanyId = 2,
                            CustomerId = 10,
                            Time = new DateTime(2024, 7, 8, 10, 22, 51, 16, DateTimeKind.Local).AddTicks(4379)
                        });
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Name = "Ermin"
                        },
                        new
                        {
                            CustomerId = 2,
                            Name = "Oskar"
                        },
                        new
                        {
                            CustomerId = 3,
                            Name = "Sharam"
                        },
                        new
                        {
                            CustomerId = 4,
                            Name = "Christian"
                        },
                        new
                        {
                            CustomerId = 5,
                            Name = "Lena"
                        },
                        new
                        {
                            CustomerId = 6,
                            Name = "Andreas"
                        },
                        new
                        {
                            CustomerId = 7,
                            Name = "Emily"
                        },
                        new
                        {
                            CustomerId = 8,
                            Name = "David"
                        },
                        new
                        {
                            CustomerId = 9,
                            Name = "Sophia"
                        },
                        new
                        {
                            CustomerId = 10,
                            Name = "Alexander"
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
