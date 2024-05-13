using Microsoft.EntityFrameworkCore;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;

namespace Project.Advanced.Net.Services
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync() =>
            await _context.Companies.Include(c => c.Appointments).ToListAsync();

        public async Task<Company> GetByIdAsync(int id) =>
            await _context.Companies
                .Include(c => c.Appointments)
                .FirstOrDefaultAsync(c => c.CompanyId == id);

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }

}
