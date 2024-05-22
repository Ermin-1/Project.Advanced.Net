﻿using Project.Advanced.Net.DTOs;
using ProjectModels;

namespace Project.Advanced.Net.Mappers
{
    public static class CustomerMapper
    {
        // Full DTO
        public static CustomerDto ToDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };
        }

        public static Customer ToEntity(this CustomerDto customerDto)
        {
            return new Customer
            {
                CustomerId = customerDto.Id,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                  Email = customerDto.Email
            };
        }

        // Summary DTO
        public static CustomerSummaryDto ToSummaryDto(this Customer customer)
        {
            return new CustomerSummaryDto
            {
                Id = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}
