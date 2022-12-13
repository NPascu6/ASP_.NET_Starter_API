using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DBContextBase _dbContext;

        public UserRoleRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _dbContext.UserRoles.ToList();
        }

        public UserRole? Get(int id)
        {
            return _dbContext.UserRoles.FirstOrDefault(ur => ur.UserRoleId == id);
        }
    }
}
