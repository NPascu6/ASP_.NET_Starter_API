using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DBContextBase _dbContext;

        public UserRoleRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _dbContext.UserRoles.ToListAsync();
        }

        public async Task<UserRole?> GetAsync(int id)
        {
            return await _dbContext.UserRoles.FirstOrDefaultAsync(ur => ur.UserRoleId == id);
        }

        public Task<UserRole> AddAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> UpdateAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
