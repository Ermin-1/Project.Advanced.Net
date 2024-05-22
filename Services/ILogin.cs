using ProjectModels;

namespace Project.Advanced.Net.Services
{
    public interface ILogin : IRepository<LoginInfo>
    {
        Task<int?> GetCustomerIdByEmail(string email);
        Task<int?> GetCompanyIdByEmail(string email);
        Task<LoginInfo> GetByEmail(string email);
        Task<LoginInfo> GetByCustomerId(int customerId);

    }
}
