using Project.Advanced.Net.DTOs;
using ProjectModels;

namespace Project.Advanced.Net.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDto ToDto(this Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.AppointmentId,
                Date = appointment.Time,
                CustomerId = appointment.CustomerId,
                FirstName = appointment.Customer.FirstName,
                LastName = appointment.Customer.LastName,
                Address = appointment.Customer.Address,
                PhoneNumber = appointment.Customer.PhoneNumber,
                Email = appointment.Customer.Email,
                CompanyId = appointment.CompanyId,
                Name = appointment.Company.Name,
                CompanyEmail = appointment.Company.Email
            };
        }

        public static Appointment ToEntity(this AppointmentDto appointmentDto)
        {
            return new Appointment
            {
                AppointmentId = appointmentDto.Id,
                Time = appointmentDto.Date,
                CustomerId = appointmentDto.CustomerId,
                CompanyId = appointmentDto.CompanyId
            };
        }
    }
}
