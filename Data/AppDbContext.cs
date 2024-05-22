using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Models;
using ProjectModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Projekt___Avancerad_.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistories { get; set; }
        public DbSet<LoginInfo> LoginInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Appointment>()
        //   .HasOne(a => a.Customer)
        //   .WithMany(c => c.Appointments)
        //   .HasForeignKey(a => a.CustomerId);

        //    modelBuilder.Entity<Appointment>()
        //   .HasOne(a => a.Company)
        //   .WithMany(c => c.Appointments)
        //    .HasForeignKey(a => a.CompanyId);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Ermin",
                LastName = "Husic",
                Address = "Campusvägen 7",
                PhoneNumber = 0734141429,
                Email = "ermin.husic@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Oskar",
                LastName = "Johansson",
                Address = "Storgatan 10",
                PhoneNumber = 0723456789,
                Email = "oskar.johansson@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Sharam",
                LastName = "Khan",
                Address = "Lilla vägen 3",
                PhoneNumber = 0734567890,
                Email = "sharam.khan@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 4,
                FirstName = "Christian",
                LastName = "Andersson",
                Address = "Parkgatan 15",
                PhoneNumber = 0765432109,
                Email = "christian.andersson@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 5,
                FirstName = "Lena",
                LastName = "Eriksson",
                Address = "Skolgatan 2",
                PhoneNumber = 0721567890,
                Email = "lena.eriksson@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 6,
                FirstName = "Andreas",
                LastName = "Lindström",
                Address = "Kyrkvägen 6",
                PhoneNumber = 0709876543,
                Email = "andreas.lindstrom@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 7,
                FirstName = "Emily",
                LastName = "Nilsson",
                Address = "Strandvägen 12",
                PhoneNumber = 0723456781,
                Email = "emily.nilsson@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 8,
                FirstName = "David",
                LastName = "Gustafsson",
                Address = "Backstugan 4",
                PhoneNumber = 0761234567,
                Email = "david.gustafsson@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 9,
                FirstName = "Sophia",
                LastName = "Berg",
                Address = "Musselvägen 4",
                PhoneNumber = 0723456782,
                Email = "sophia.berg@example.com"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 10,
                FirstName = "Alexander",
                LastName = "Larsson",
                Address = "Storgatan 2",
                PhoneNumber = 0768765432,
                Email = "alexander.larsson@example.com"
            });


            //login


            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 1,
                EMail = "ermin.husic@example.com",
                Password = "password1",
                Role = "customer",
                CustomerId = 1
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 2,
                EMail = "oskar.johansson@example.com",
                Password = "password2",
                Role = "customer",
                CustomerId = 2,
              
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 3,
                EMail = "sharam.khan@example.com",
                Password = "password3",
                Role = "customer",
                CustomerId = 3,
              
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 4,
                EMail = "christian.andersson@example.com",
                Password = "password4",
                Role = "customer",
                CustomerId = 4,
             
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 5,
                EMail = "lena.eriksson@example.com",
                Password = "password5",
                Role = "customer",
                CustomerId = 5,
               
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 6,
                EMail = "andreas.lindstrom@example.com",
                Password = "password6",
                Role = "customer",
                CustomerId = 6,
                
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 7,
                EMail = "emily.nilsson@example.com",
                Password = "password7",
                Role = "customer",
                CustomerId = 7,
                
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 8,
                EMail = "david.gustafsson@example.com",
                Password = "password8",
                Role = "customer",
                CustomerId = 8,
              
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 9,
                EMail = "sophia.berg@example.com",
                Password = "password9",
                Role = "customer",
                CustomerId = 9,
               
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 10,
                EMail = "alexander.larsson@example.com",
                Password = "password10",
                Role = "customer",
                CustomerId = 10,
              
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 11,
                EMail = "admin@admin.se",
                Password = "1234",
                Role = "admin"
            });



            //company

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                Name = "Apple",
                Email = "admin@apple.com"

            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 2,
                Name = "Samsung",
                Email = "admin@samsung.com"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 3,
                Name = "Xiaomi",
                Email = "admin@xiaomi.com"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 4,
                Name = "Google",
                Email = "admin@google.com"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 5,
                Name = "Microsoft",
                Email = "admin@microsoft.com"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 6,
                Name = "Amazon",
                Email = "admin@amazon.com"
            });


            //company login

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 17,
                EMail = "admin@apple.com",
                Password = "password1",
                Role = "company",
                CompanyId = 1
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 12,
                EMail = "admin@samsung.com",
                Password = "password2",
                Role = "company",
                CompanyId = 2
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 13,
                EMail = "admin@xiaomi.com",
                Password = "password3",
                Role = "company",
                CompanyId = 3
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 14,
                EMail = "admin@google.com",
                Password = "password4",
                Role = "company",
                CompanyId = 4
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 15,
                EMail = "admin@microsoft.com",
                Password = "password5",
                Role = "company",
                CompanyId = 5
            });

            modelBuilder.Entity<LoginInfo>().HasData(new LoginInfo
            {
                Id = 16,
                EMail = "admin@amazon.com",
                Password = "password6",
                Role = "company",
                CompanyId = 6
            });


            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 1, Time = DateTime.Now, CustomerId = 1, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 2, Time = DateTime.Now.AddDays(1), CustomerId = 1, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 3, Time = DateTime.Now.AddDays(2), CustomerId = 1, CompanyId = 1 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 4, Time = DateTime.Now, CustomerId = 2, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 5, Time = DateTime.Now.AddDays(10), CustomerId = 2, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 6, Time = DateTime.Now.AddDays(20), CustomerId = 2, CompanyId = 1 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 7, Time = DateTime.Now, CustomerId = 3, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 8, Time = DateTime.Now.AddDays(15), CustomerId = 3, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 9, Time = DateTime.Now.AddDays(20), CustomerId = 3, CompanyId = 2 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 10, Time = DateTime.Now, CustomerId = 4, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 11, Time = DateTime.Now.AddDays(1), CustomerId = 4, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 12, Time = DateTime.Now.AddDays(2), CustomerId = 4, CompanyId = 3 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 13, Time = DateTime.Now, CustomerId = 5, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 14, Time = DateTime.Now.AddDays(10), CustomerId = 5, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 15, Time = DateTime.Now.AddDays(15), CustomerId = 5, CompanyId = 5 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 16, Time = DateTime.Now, CustomerId = 6, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 17, Time = DateTime.Now.AddDays(8), CustomerId = 6, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 18, Time = DateTime.Now.AddDays(2), CustomerId = 6, CompanyId = 5 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 19, Time = DateTime.Now, CustomerId = 7, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 20, Time = DateTime.Now.AddDays(25), CustomerId = 7, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 21, Time = DateTime.Now.AddDays(21), CustomerId = 7, CompanyId = 1 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 22, Time = DateTime.Now, CustomerId = 8, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 23, Time = DateTime.Now.AddDays(4), CustomerId = 8, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 24, Time = DateTime.Now.AddDays(8), CustomerId = 8, CompanyId = 2 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 25, Time = DateTime.Now, CustomerId = 9, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 26, Time = DateTime.Now.AddDays(4), CustomerId = 9, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 27, Time = DateTime.Now.AddDays(9), CustomerId = 9, CompanyId = 3 });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 28, Time = DateTime.Now, CustomerId = 10, CompanyId = 4 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 29, Time = DateTime.Now.AddDays(1), CustomerId = 10, CompanyId = 4 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 30, Time = DateTime.Now.AddDays(2), CustomerId = 10, CompanyId = 4 });


        }


    }
}
