
using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Wrong inputs");
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Wrong inputs");
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Wrong inputs");
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

                // Logga upd
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
                return StatusCode(StatusCodes.Status500InternalServerError, $"Wrong inputs");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppointmentDto>> Delete(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
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

                    // Ta bort avtalet efter att historikposten har lagts till
                    await _appointmentRepository.DeleteAsync(id);

                    // Spara ändringarna i databasen
                    await _context.SaveChangesAsync();

                    // Bekräfta transaktionen
                    await transaction.CommitAsync();

                    return Ok(appointment.ToDto());
                }
                catch (Exception ex)
                {
                    // Återställ transaktionen vid fel
                    await transaction.RollbackAsync();
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not delete");
                }
            }
        }


        // Ny metod för att få bokningar för en specifik vecka
        [HttpGet("week/{year}/{week}/{companyId}")] // Lagt till {companyId} i URL-rutten
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByWeek(int year, int week, int companyId) // Lagt till companyId som parameter
        {
            try
            {
                var firstDayOfWeek = FirstDateOfWeek(year, week);
                var lastDayOfWeek = firstDayOfWeek.AddDays(7).AddTicks(-1);
                var appointments = await _appointmentRepository.GetAllAsync();
                var weeklyAppointments = appointments
                    .Where(a => a.Time >= firstDayOfWeek && a.Time <= lastDayOfWeek && a.CompanyId == companyId) // Lagt till filtrering på companyId för uppgfit
                    .ToList();
                var weeklyAppointmentDtos = weeklyAppointments.Select(a => a.ToDto());
                return Ok(weeklyAppointmentDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not get appointments");
            }
        }

        // Ny metod för att få bokningar för en specifik månad
        [HttpGet("month/{year}/{month}/{companyId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByMonth(int year, int month, int companyId)
        {
            try
            {
                // Skapa ett DateTime-objekt för den första dagen i den angivna månaden
                var firstDayOfMonth = new DateTime(year, month, 1);

                // Skapa ett DateTime-objekt för den sista dagen i den angivna månaden
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);

                // Hämta alla bokningar från databasen
                var appointments = await _appointmentRepository.GetAllAsync();

                // Filtrera bokningarna för att få de som faller inom den angivna månaden och tillhör den angivna företaget
                var monthlyAppointments = appointments.Where(a => a.Time >= firstDayOfMonth && a.Time <= lastDayOfMonth && a.CompanyId == companyId).ToList();

                // Konvertera filtrerade bokningar till DTO-objekt
                var monthlyAppointmentDtos = monthlyAppointments.Select(a => a.ToDto());

                // Returnera de filtrerade bokningarna som en lista med DTO-objekt
                return Ok(monthlyAppointmentDtos);
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not get appointments");
            }
        }

        // Privat metod för att få det första datumet i en vecka för ett  år och veckonummer
        private DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            // Skapa ett DateTime-objekt för den 1 januari det givna året
            DateTime jan1 = new DateTime(year, 1, 1);

            // Beräkna hur många dagar det är till den första torsdagen i året
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Lägg till offseten till 1 januari för att få den första torsdagen
            DateTime firstThursday = jan1.AddDays(daysOffset);

            // Hämta kalendern 
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;

            // Hämta veckonumret för den första torsdagen pga ISO standard
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            // Justera veckonumret om den första veckan inte är vecka 1
            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            // Lägg till veckonumret gånger 7 dagar till den första torsdagen för att få rätt vecka
            var result = firstThursday.AddDays(weekNum * 7);

            // Justera tillbaka tre dagar för att få måndagen i den veckan
            return result.AddDays(-3);
        }

    }
}
