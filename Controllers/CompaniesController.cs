using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Models;
using Project.Advanced.Net.Services;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Advanced.Net.Mappers;
using Projekt___Avancerad_.NET.Data;

namespace Project.Advanced.Net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly AppDbContext _context;

        public CompaniesController(
            IRepository<Company> companyRepository,
             AppDbContext context)
        {
            _companyRepository = companyRepository;
            _context = context;
        }

        [Authorize(Policy = "AdminOrCompanyPolicy")]
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

        [Authorize(Policy = "AdminOrCompanyPolicy")]
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

        [Authorize(Policy = "AdminOrCompanyPolicy")]
        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Post([FromBody] CompanyDto companyDto)
        {
            try
            {
                var company = companyDto.ToEntity();

                await _companyRepository.AddAsync(company);

                // Skapa LoginInfo för företaget
                var loginInfo = new LoginInfo
                {
                    EMail = company.Email,
                    Password = "defaultpassword", // eller generera ett starkt lösenord
                    Role = "company",
                    CompanyId = company.CompanyId
                };

                await _context.LoginInfos.AddAsync(loginInfo);
                await _context.SaveChangesAsync();

                var createdCompany = await _companyRepository.GetByIdAsync(company.CompanyId);
                return CreatedAtAction(nameof(Get), new { id = company.CompanyId }, createdCompany.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not post company. Error: {ex.Message}");
            }
        }


        [Authorize(Policy = "AdminOrCompanyPolicy")]
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

        [Authorize(Policy = "AdminPolicy")]
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
