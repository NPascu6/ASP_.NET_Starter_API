using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContextBase _dbContext;

        public UserRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.UserRole)
                .Include(c => c.UserDetails)
                .ToListAsync();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _dbContext.Users
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.Wallet)
                        .ThenInclude(w => w.Assets)
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.UserRole)
                .Include(c => c.UserDetails)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
