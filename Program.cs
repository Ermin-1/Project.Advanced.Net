
using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Services;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;
using System;

namespace Project.Advanced.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Register repositories for dependency injection
            builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<Appointment>, AppointmentRepository>();
            builder.Services.AddScoped<IRepository<Company>, CompanyRepository>();

            //connectionstring till SQL
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            ////json serialazion
            //builder.Services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
