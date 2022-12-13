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

        public IEnumerable<UserDetails> GetAll()
        {
            return _dbContext.UserDetails
                .Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .ToList();
        }

        public UserDetails? Get(int id)
        {
            return _dbContext.UserDetails.Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .FirstOrDefault(userDetails => userDetails.UserDetailsId == id);
        }

        public UserDetails? GetByUserId(int id)
        {
            return _dbContext.UserDetails.Include(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(d => d.UserRole)
                .FirstOrDefault(userDetails => userDetails.UserId == id);
        }

    }
}
