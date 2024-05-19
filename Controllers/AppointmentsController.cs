﻿using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Data;
using Project.Advanced.Net.Services;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;
using Project.Advanced.Net.DTOs;
using Project.Advanced.Net.Mappers;


namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IAppointmentHistoryRepository _historyRepository;
        private readonly AppDbContext _context;

        public AppointmentsController(IRepository<Appointment> appointmentRepository, IAppointmentHistoryRepository historyRepository, AppDbContext context)
        {
            _appointmentRepository = appointmentRepository;
            _historyRepository = historyRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get(
            string sortBy = "date",
            string filterBy = "",
            string filterValue = "")
        {
            try
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

                var appointmentDtos = appointments.Select(a => a.ToDto());
                return Ok(appointmentDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> Get(int id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(appointment.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> Post([FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                var appointment = appointmentDto.ToEntity();

                // Kontrollera om kunden redan finns
                if (appointment.CustomerId != 0)
                {
                    var existingCustomer = await _context.Customers.FindAsync(appointment.CustomerId);
                    if (existingCustomer == null)
                    {
                        return BadRequest("Customer not found.");
                    }
                    appointment.Customer = existingCustomer;
                }

                // Kontrollera om företaget redan finns
                if (appointment.CompanyId != 0)
                {
                    var existingCompany = await _context.Companies.FindAsync(appointment.CompanyId);
                    if (existingCompany == null)
                    {
                        return BadRequest("Company not found.");
                    }
                    appointment.Company = existingCompany;
                }

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
                await _context.SaveChangesAsync(); // Save changes to ensure history is saved

                var createdAppointment = await _appointmentRepository.GetByIdAsync(appointment.AppointmentId);
                return CreatedAtAction(nameof(Get), new { id = appointment.AppointmentId }, createdAppointment.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentDto>> Put(int id, [FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                if (id != appointmentDto.Id)
                {
                    return BadRequest("Appointment ID doesn't match!");
                }
                var appointment = appointmentDto.ToEntity();
                var existingAppointment = await _appointmentRepository.GetByIdAsync(id);
                if (existingAppointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                existingAppointment.Time = appointment.Time;
                existingAppointment.CustomerId = appointment.CustomerId;
                existingAppointment.CompanyId = appointment.CompanyId;


                await _appointmentRepository.UpdateAsync(existingAppointment);

                // Log the update
                var history = new AppointmentHistory
                {
                    AppointmentId = appointment.AppointmentId,
                    Action = "Updated",
                    Changes = "Appointment updated",
                    Timestamp = DateTime.Now
                };
                await _historyRepository.AddAsync(history);

                var updatedAppointment = await _appointmentRepository.GetByIdAsync(appointment.AppointmentId);
                return Ok(updatedAppointment.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppointmentDto>> Delete(int id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                // Skapa en ny historikpost
                var appointmentHistory = new AppointmentHistory
                {
                    AppointmentId = appointment.AppointmentId,
                    Action = "Deleted",
                    Changes = "Appointment was deleted.",
                    Timestamp = DateTime.Now
                };

                await _historyRepository.AddAsync(appointmentHistory); // Lägg till historikposten
                await _appointmentRepository.DeleteAsync(id);

                return Ok(appointment.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        // Ny metod för att få bokningar för en specifik vecka
        [HttpGet("week/{year}/{week}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByWeek(int year, int week)
        {
            try
            {
                var firstDayOfWeek = FirstDateOfWeek(year, week);
                var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddTicks(-1);
                var appointments = await _appointmentRepository.GetAllAsync();
                var weeklyAppointments = appointments.Where(a => a.Time >= firstDayOfWeek && a.Time <= lastDayOfWeek).ToList();
                var weeklyAppointmentDtos = weeklyAppointments.Select(a => a.ToDto());
                return Ok(weeklyAppointmentDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        // Ny metod för att få bokningar för en specifik månad
        [HttpGet("month/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByMonth(int year, int month)
        {
            try
            {
                var firstDayOfMonth = new DateTime(year, month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
                var appointments = await _appointmentRepository.GetAllAsync();
                var monthlyAppointments = appointments.Where(a => a.Time >= firstDayOfMonth && a.Time <= lastDayOfMonth).ToList();
                var monthlyAppointmentDtos = monthlyAppointments.Select(a => a.ToDto());
                return Ok(monthlyAppointmentDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
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
