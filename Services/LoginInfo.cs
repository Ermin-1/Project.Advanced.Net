using Project.Advanced.Net.Models;
using ProjectModels;

namespace Project.Advanced.Net.Models
{
    public class LoginInfo
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public string Role { get; set; }

    }
}
