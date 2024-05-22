using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Models;
using ProjectModels;
using Projekt___Avancerad_.NET.Data;
namespace Project.Advanced.Net.Services
{
    public class LoginRepository 
    {
        private AppDbContext _appDbContext;
        public LoginRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
 
        public async Task<LoginInfo> Add(LoginInfo entity)
        {
            var result = await _appDbContext.LoginInfos.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<LoginInfo> Delete(int id)
        {
            var result = await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.Id == id);
            if (result != null)
            {
                _appDbContext.LoginInfos.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LoginInfo>> GetAll()
        {
            return await _appDbContext.LoginInfos.ToListAsync();
        }

        public Task<IEnumerable<LoginInfo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LoginInfo> GetByCustomerId(int customerId)
        {
            return await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.CustomerId == customerId);
        }


        public async Task<LoginInfo> GetByEmail(string email)
        {
            return await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.EMail == email);
        }

        public async Task<LoginInfo> GetById(int id)
        {
            return await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.Id == id);
        }

        public Task<LoginInfo> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetCompanyIdByEmail(string email)
        {
            var loginInfo = await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.EMail == email);
            return loginInfo.CompanyId;
        }

        public async Task<int?> GetCustomerIdByEmail(string email)
        {
            var loginInfo = await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.EMail == email);
            return loginInfo.CustomerId;
        }

        public async Task<LoginInfo> Update(LoginInfo entity)
        {
            var result = await _appDbContext.LoginInfos.FirstOrDefaultAsync(l => l.Id == entity.Id);
            if (result != null)
            {
                result.EMail = entity.EMail;
                result.CompanyId = entity.CompanyId;
                result.CustomerId = entity.CustomerId;
                result.Role = entity.Role;
                result.Password = entity.Password;

                return result;
            }
            return null;
        }

        public Task UpdateAsync(LoginInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
