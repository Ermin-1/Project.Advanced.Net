using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Data;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;

namespace Project.Advanced.Net.Services
{
    public class AppointmentHistoryRepository : IAppointmentHistoryRepository
    {
        private readonly AppDbContext _context;

        public AppointmentHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AppointmentHistory history)
        {
            _context.AppointmentHistories.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _context.AppointmentHistories
                .Where(h => h.AppointmentId == appointmentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllAsync() 
        {
            return await _context.AppointmentHistories.ToListAsync();
        }

    }  
}