using Microsoft.EntityFrameworkCore;
using Project.Advanced.Net.Models;
using Projekt___Avancerad_.NET.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Avancerad_.NET.Authentication
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string username)
        {
            var user = await _appDbContext.LoginInfos.FirstOrDefaultAsync(u => u.EMail == username);
            if (user != null)
            {
                var roles = new List<string> { user.Role };
                return roles;
            }
            return Enumerable.Empty<string>();
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = await _appDbContext.LoginInfos.FirstOrDefaultAsync(u => u.EMail == username && u.Password == password);
            return user != null;
        }

        public async Task CreateUserAsync(LoginInfo loginInfo)
        {
            _appDbContext.LoginInfos.Add(loginInfo);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
