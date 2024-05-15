using ProjectModels;
using Projekt___Avancerad_.NET.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Advanced.Net.Data
{
    public interface IAppointmentHistoryRepository
    {
        Task AddAsync(AppointmentHistory history);
        Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId);
        Task<IEnumerable<AppointmentHistory>> GetAllAsync();
    }

  
    
}
