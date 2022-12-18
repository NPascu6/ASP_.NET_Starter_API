using ASP_CORE_BASIC_NET_6_API.Repository.Models;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole?> GetAsync(int id);
        Task<UserRole> AddAsync(UserRole userRole);
        Task<UserRole?> UpdateAsync(UserRole userRole, int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAllAsync();
    }
}
