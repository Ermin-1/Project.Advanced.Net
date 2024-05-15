using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Services;
using ProjectModels;

namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IRepository<Appointment> _appointmentRepository;

        public AppointmentsController(IRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
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
                        a.Customer.LastName.Contains(filterValue, StringComparison.OrdinalIgnoreCase) ||
                        a.Customer.Address.Contains(filterValue, StringComparison.OrdinalIgnoreCase) 
                    ).ToList(),

                    "company" => appointments.Where(a => 
                    a.Company.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase)).ToList(),

                    "id" => appointments.Where(a =>
                        a.Customer.CustomerId.ToString() == filterValue ||
                        a.AppointmentId.ToString() == filterValue
                    ).ToList(),

                    _ => appointments
                };
            }

            // Sortera bokningar
            appointments = sortBy.ToLower() switch
            {
                "date" => appointments.OrderBy(a => a.Time).ToList()
            
            };

            return Ok(appointments);
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult> Post([FromBody] Appointment appointment)
        {
            ModelState.Remove("Customer");
            ModelState.Remove("Company");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _appointmentRepository.AddAsync(appointment);
            return CreatedAtAction(nameof(Get), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }
            await _appointmentRepository.UpdateAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }


        //Egna metoder för appointment 
        [HttpGet("customers-with-appointments-this-week")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersWithAppointmentsThisWeek()
        {
            var repository = _appointmentRepository as AppointmentRepository;
            if (repository == null)
            {
                return BadRequest("Repository casting failed");
            }

            var customers = await repository.GetCustomersWithAppointmentsThisWeek();
            if (customers == null || !customers.Any())
            {
                return NotFound("No customers with appointments this week.");
            }
            return Ok(customers);
        }


        [HttpGet("count-for-customer/{customerId}/{weekOfYear}")]
        public async Task<ActionResult<int>> GetAppointmentCountForCustomerThisWeek(int customerId, int weekOfYear)
        {
            var repository = _appointmentRepository as AppointmentRepository;
            if (repository == null)
            {
                return BadRequest("Repository casting failed");
            }

            var count = await repository.GetAppointmentCountForCustomerThisWeek(customerId, weekOfYear);
            return Ok(count);
        }
    }
}
