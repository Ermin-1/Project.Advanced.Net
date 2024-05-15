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
        public async Task<ActionResult<IEnumerable<Company>>> Get(
             string sortBy = "name",
             string filterBy = "",
             string filterValue = "")
        {
            var companies = await _companyRepository.GetAllAsync();

            // Filtrera företag
            if (!string.IsNullOrEmpty(filterBy) && !string.IsNullOrEmpty(filterValue))
            {
                companies = filterBy.ToLower() switch
                {
                    "name" => companies.Where(c =>
                        c.Name.Contains(filterValue, StringComparison.OrdinalIgnoreCase)
                    ).ToList(),
                    "id" => companies.Where(c =>
                        c.CompanyId.ToString() == filterValue
                    ).ToList(),
                    _ => companies
                };
            }

            // Sortera företag
            companies = sortBy.ToLower() switch
            {
                "name" => companies.OrderBy(c => c.Name).ToList(),
                "id" => companies.OrderBy(c => c.CompanyId).ToList(),
                _ => companies.OrderBy(c => c.CompanyId).ToList(),
            };

            return Ok(companies);
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
