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
        public async Task<ActionResult<IEnumerable<Appointment>>> Get()
        {
            return Ok(await _appointmentRepository.GetAllAsync());
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

    }
}
