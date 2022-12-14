using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly DBContextBase _dbContext;

        public UserDetailsRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await _dbContext.UserDetails
                .Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .ToListAsync();
        }

        public async Task<UserDetails?> GetAsync(int id)
        {
            return await  _dbContext.UserDetails.Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .FirstOrDefaultAsync(userDetails => userDetails.UserDetailsId == id);
        }

        public async Task<UserDetails?> GetByUserIdAsync(int id)
        {
            return await _dbContext.UserDetails.Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .FirstOrDefaultAsync(userDetails => userDetails.UserId == id);
        }

    }
}
