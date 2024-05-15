using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Services;
using ProjectModels;

namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get(
               string sortBy = "name",
               string filterBy = "",
               string filterValue = "")
        {
            var customers = await _customerRepository.GetAllAsync();

            // Filtrera kunder
            if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterValue))
            {
                customers = customers.Where(c =>
                    c.GetType().GetProperty(filterBy)?.GetValue(c, null)?.ToString().Contains(filterValue) == true
                ).ToList();
            }

            // Sortera kunder
            customers = sortBy.ToLower() switch
            {
                "name" => customers.OrderBy(c => c.FirstName).ToList(),
                "phone" => customers.OrderBy(c => c.PhoneNumber).ToList(),
                _ => customers.OrderBy(c => c.CustomerId).ToList(),
            };

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return NoContent();
        }



    }
}
