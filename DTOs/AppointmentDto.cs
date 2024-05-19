namespace Project.Advanced.Net.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
    }
}
