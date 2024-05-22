using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Models;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;
using System.Reflection.Metadata.Ecma335;

namespace Project.Advanced.Net.Services
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }


 


        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
           return await _context.Customers.Include(c => c.Appointments).ToListAsync();

        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.Include(c => c.Appointments)
         .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerWithAppointments(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            return customer;
        }

    }
}
