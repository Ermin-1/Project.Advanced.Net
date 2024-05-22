namespace Project.Advanced.Net.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string CompanyEmail { get; set; }
    }
}
