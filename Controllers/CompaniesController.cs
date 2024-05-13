using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Project.Advanced.Net.Services;
using ProjectModels;

namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepository<Company> _companyRepository;

        public CompaniesController(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return Ok(await _companyRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Company company)
        {
            await _companyRepository.AddAsync(company);
            return CreatedAtAction(nameof(Get), new { id = company.CompanyId }, company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }
            await _companyRepository.UpdateAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _companyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
