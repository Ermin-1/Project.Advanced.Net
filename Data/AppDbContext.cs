using Microsoft.EntityFrameworkCore;
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
                PhoneNumber = 0734141429
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Oskar",
                LastName = "Johansson",
                Address = "Storgatan 10",
                PhoneNumber = 0723456789
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Sharam",
                LastName = "Khan",
                Address = "Lilla vägen 3",
                PhoneNumber = 0734567890
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 4,
                FirstName = "Christian",
                LastName = "Andersson",
                Address = "Parkgatan 15",
                PhoneNumber = 0765432109
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 5,
                FirstName = "Lena",
                LastName = "Eriksson",
                Address = "Skolgatan 2",
                PhoneNumber = 0721567890
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 6,
                FirstName = "Andreas",
                LastName = "Lindström",
                Address = "Kyrkvägen 6",
                PhoneNumber = 0709876543
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 7,
                FirstName = "Emily",
                LastName = "Nilsson",
                Address = "Strandvägen 12",
                PhoneNumber = 0723456781
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 8,
                FirstName = "David",
                LastName = "Gustafsson",
                Address = "Backstugan 4",
                PhoneNumber = 0761234567
            });


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 9,
                FirstName = "Sophia",
                LastName = "Berg",
                Address = "Musselvägen 4",
                PhoneNumber = 0723456782
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 10,
                FirstName = "Alexander",
                LastName = "Larsson",
                Address = "Storgatan 2",
                PhoneNumber = 0768765432
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                Name = "Apple"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 2,
                Name = "Samsung"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 3,
                Name = "Xiaomi"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 4,
                Name = "Google"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 5,
                Name = "Microsoft"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 6,
                Name = "Amazon"
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
