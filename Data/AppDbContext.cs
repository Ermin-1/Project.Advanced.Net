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
                Name = "Ermin"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                Name = "Oskar"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                Name = "Sharam"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 4,
                Name = "Christian"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 5,
                Name = "Lena"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 6,
                Name = "Andreas"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 7,
                Name = "Emily"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 8,
                Name = "David"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 9,
                Name = "Sophia"
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 10,
                Name = "Alexander"
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
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 2, Time = DateTime.Now.AddDays(10), CustomerId = 2, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 3, Time = DateTime.Now.AddDays(20), CustomerId = 3, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 4, Time = DateTime.Now.AddDays(30), CustomerId = 4, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 5, Time = DateTime.Now.AddDays(40), CustomerId = 1, CompanyId = 4 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 6, Time = DateTime.Now.AddDays(50), CustomerId = 2, CompanyId = 4 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 7, Time = DateTime.Now.AddDays(5), CustomerId = 5, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 8, Time = DateTime.Now.AddDays(15), CustomerId = 6, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 9, Time = DateTime.Now.AddDays(25), CustomerId = 5, CompanyId = 6 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 10, Time = DateTime.Now.AddDays(35), CustomerId = 6, CompanyId = 6 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 11, Time = DateTime.Now.AddDays(7), CustomerId = 7, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 12, Time = DateTime.Now.AddDays(14), CustomerId = 8, CompanyId = 2 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 13, Time = DateTime.Now.AddDays(21), CustomerId = 9, CompanyId = 3 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 14, Time = DateTime.Now.AddDays(28), CustomerId = 10, CompanyId = 4 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 15, Time = DateTime.Now.AddDays(35), CustomerId = 7, CompanyId = 5 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 16, Time = DateTime.Now.AddDays(42), CustomerId = 8, CompanyId = 6 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 17, Time = DateTime.Now.AddDays(49), CustomerId = 9, CompanyId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 18, Time = DateTime.Now.AddDays(56), CustomerId = 10, CompanyId = 2 });


        }


    }
}
