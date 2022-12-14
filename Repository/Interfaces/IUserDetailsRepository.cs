using ASP_CORE_BASIC_NET_6_API.Models.Domain;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();
        Task<UserDetails?> GetAsync(int id);
        Task<UserDetails?> GetByUserIdAsync(int id);
        Task<UserDetails> AddAsync(UserDetails userDetails);
        Task<UserDetails> UpdateAsync(UserDetails userDetails);
        Task<bool> DeleteAsync(int id);
    }
}
