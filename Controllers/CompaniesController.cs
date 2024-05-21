using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            try
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: could not get company");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            try
            {
                var company = await _companyRepository.GetByIdAsync(id);
                if (company == null)
                {
                    return NotFound($"Company with ID {id} not found.");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: could not get company");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                return CreatedAtAction(nameof(Get), new { id = company.CompanyId }, company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: could not post company");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Company company)
        {
            try
            {
                if (id != company.CompanyId)
                {
                    return BadRequest($"Company ID {id} does not match the ID of the company being updated.");
                }
                await _companyRepository.UpdateAsync(company);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: could not update company");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var company = await _companyRepository.GetByIdAsync(id);
                if (company == null)
                {
                    return NotFound($"Company with ID {id} not found.");
                }
                await _companyRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: could not delete company");
            }
        }
    }
}
