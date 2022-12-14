using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<bool> DeleteAsync(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User?> UpdateAsync(User user, int id)
        {
            var existing = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if(existing != null)
            {
                existing.UserDetails = user.UserDetails;
                existing.LastName = user.LastName;
                existing.FirstName = user.FirstName;
                existing.Email = user.Email;

                _dbContext.Users.Update(existing);
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
