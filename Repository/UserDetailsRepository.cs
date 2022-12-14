using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<UserDetails> AddAsync(UserDetails userDetails)
        {
            await _dbContext.UserDetails.AddAsync(userDetails);
            await _dbContext.SaveChangesAsync();

            return userDetails;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userDetails = _dbContext.UserDetails.FirstOrDefault(u => u.UserDetailsId == id);

            if (userDetails != null)
            {
                _dbContext.UserDetails.Remove(userDetails);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserDetails?> UpdateAsync(UserDetails userDetails, int userId)
        {
            var existing = await _dbContext.UserDetails.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existing != null)
            {
                existing.BirthDate = userDetails.BirthDate;
                existing.PhoneNumber = userDetails.PhoneNumber;
                existing.Address = userDetails.Address;

                _dbContext.UserDetails.Update(existing);
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
