using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Data;
using Project.Advanced.Net.Services;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IAppointmentHistoryRepository _historyRepository;

        public AppointmentsController(IRepository<Appointment> appointmentRepository, IAppointmentHistoryRepository historyRepository)
        {
            _appointmentRepository = appointmentRepository;
            _historyRepository = historyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> Get(
            string sortBy = "date",
            string filterBy = "",
            string filterValue = "")
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            // Filtrera bokningar
            if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterValue))
            {
                appointments = filterBy.ToLower() switch
                {
                    "customer" => appointments.Where(a =>
                        a.Customer.FirstName.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ||
                        a.Customer.LastName.Contains(filterValue, StringComparison.OrdinalIgnoreCase)
                    ).ToList(),
                    "phone" => appointments.Where(a =>
                        a.Customer.PhoneNumber.ToString().Contains(filterValue)
                    ).ToList(),
                    "id" => appointments.Where(a =>
                        a.Customer.CustomerId.ToString() == filterValue ||
                        a.AppointmentId.ToString() == filterValue
                    ).ToList(),
                    "company" => appointments.Where(a =>
                        a.Company.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase)
                    ).ToList(),
                    _ => appointments
                };
            }

            // Sortera bokningar
            appointments = sortBy.ToLower() switch
            {
                "date" => appointments.OrderBy(a => a.Time).ToList(),
                "customer" => appointments.OrderBy(a => a.Customer.LastName).ThenBy(a => a.Customer.FirstName).ToList(),
                "company" => appointments.OrderBy(a => a.Company.Name).ToList(),
                _ => appointments.OrderBy(a => a.AppointmentId).ToList(),
            };

            return Ok(appointments);
        }

        [HttpGet("{Appointment-id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }




        [HttpPost]
        public async Task<ActionResult<Appointment>> Post(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);

            // Logga skapandet av bokningen
            var history = new AppointmentHistory
            {
                AppointmentId = appointment.AppointmentId,
                Action = "Created",
                Changes = "Appointment created",
                Timestamp = DateTime.UtcNow
            };
            await _historyRepository.AddAsync(history);

            return CreatedAtAction(nameof(Get), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.UpdateAsync(appointment);

            // Logga uppdateringen av bokningen
            var history = new AppointmentHistory
            {
                AppointmentId = appointment.AppointmentId,
                Action = "Updated",
                Changes = "Appointment updated",
                Timestamp = DateTime.UtcNow
            };
            await _historyRepository.AddAsync(history);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.DeleteAsync(appointment.AppointmentId);

            // Logga borttagningen av bokningen
            var history = new AppointmentHistory
            {
                AppointmentId = appointment.AppointmentId,
                Action = "Deleted",
                Changes = "Appointment deleted",
                Timestamp = DateTime.UtcNow
            };
            await _historyRepository.AddAsync(history);

            return NoContent();
        }



        // Ny metod för att få bokningar för en specifik vecka
        [HttpGet("week/{year}/{week}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByWeek(int year, int week)
        {
            var firstDayOfWeek = FirstDateOfWeek(year, week);
            var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddTicks(-1);
            var appointments = await _appointmentRepository.GetAllAsync();
            var weeklyAppointments = appointments.Where(a => a.Time >= firstDayOfWeek && a.Time <= lastDayOfWeek).ToList();
            return Ok(weeklyAppointments);
        }

        // Ny metod för att få bokningar för en specifik månad
        [HttpGet("month/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByMonth(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
            var appointments = await _appointmentRepository.GetAllAsync();
            var monthlyAppointments = appointments.Where(a => a.Time >= firstDayOfMonth && a.Time <= lastDayOfMonth).ToList();
            return Ok(monthlyAppointments);
        }

        private DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }


    }
}
