using ASP_CORE_BASIC_NET_6_API.Repository.Models;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(User user, int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAllAsync();
    }
}
