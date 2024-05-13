using Microsoft.EntityFrameworkCore;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;

namespace Project.Advanced.Net.Services
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
            await _context.Appointments.Include(a => a.Customer).Include(a => a.Company).ToListAsync();

        public async Task<Appointment> GetByIdAsync(int id) =>
            await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Company)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithAppointmentsThisWeek()
        {
            var now = DateTime.Now;
            var weekStart = now.AddDays(-(int)now.DayOfWeek);
            var weekEnd = weekStart.AddDays(7);

            return await _context.Appointments
                .Where(a => a.Time >= weekStart && a.Time < weekEnd)
                .Select(a => a.Customer)
                .Distinct()
                .ToListAsync();
        }


    }
}