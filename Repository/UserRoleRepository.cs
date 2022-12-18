using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<UserRole> AddAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();

            return userRole;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userRole = _dbContext.UserRoles.FirstOrDefault(u => u.UserRoleId == id);

            if (userRole != null)
            {
                _dbContext.UserRoles.Remove(userRole);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllAsync()
        {
            var allUsers = _dbContext.UserRoles.ToList();


            if (allUsers != null)
            {

                _dbContext.UserRoles.RemoveRange(allUsers);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserRole?> UpdateAsync(UserRole userRole, int id)
        {
            var existing = await _dbContext.UserRoles.FirstOrDefaultAsync(u => u.UserRoleId == id);
            if (existing != null)
            {
                existing.RoleName = userRole.RoleName;

                _dbContext.UserRoles.Update(existing);
                await _dbContext.SaveChangesAsync();

                return existing;
            }
            else
            {
                return null;
            }
        }
    }
}
