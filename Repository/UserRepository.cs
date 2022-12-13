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

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.UserRole)
                .Include(c => c.UserDetails)
                .ToList();
        }

        public User? Get(int id)
        {
            return _dbContext.Users
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.Wallet)
                    .ThenInclude(w => w.Assets)
                .Include(c => c.UserDetails)
                    .ThenInclude(d => d.UserRole)
                .Include(c => c.UserDetails)
                .FirstOrDefault(u => u.UserId == id);
        }
    }
}
