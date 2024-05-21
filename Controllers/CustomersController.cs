﻿using Microsoft.AspNetCore.Mvc;
using Project.Advanced.Net.Services;
using ProjectModels;
using Project.Advanced.Net.DTOs;
using Project.Advanced.Net.Mappers;

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
        public async Task<ActionResult<IEnumerable<CustomerSummaryDto>>> Get(
               string sortBy = "name",
               string filterBy = "",
               string filterValue = "")
        {
            try
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

                var customerSummaryDtos = customers.Select(c => c.ToSummaryDto());
                return Ok(customerSummaryDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not get customers");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSummaryDto>> Get(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer.ToSummaryDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not get customers");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                var customer = customerDto.ToEntity();
                await _customerRepository.AddAsync(customer);
                var createdCustomer = await _customerRepository.GetByIdAsync(customer.CustomerId); // Hämta den skapade kunden med alla uppdaterade fält
                return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, createdCustomer.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not post customers");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Put(int id, [FromBody] CustomerDto customerDto)
        {
            try
            {
                if (id != customerDto.Id)
                {
                    return BadRequest();
                }
                var customer = customerDto.ToEntity();
                await _customerRepository.UpdateAsync(customer);
                var updatedCustomer = await _customerRepository.GetByIdAsync(customer.CustomerId); // Hämta den uppdaterade kunden med alla uppdaterade fält
                return Ok(updatedCustomer.ToDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not edit customers");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerSummaryDto>> Delete(int id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                await _customerRepository.DeleteAsync(id);
                return Ok(customer.ToSummaryDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: Could not delete customers");
            }
        }
    }
}
