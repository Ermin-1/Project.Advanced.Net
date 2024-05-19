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
                CompanyId = appointment.CompanyId
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
