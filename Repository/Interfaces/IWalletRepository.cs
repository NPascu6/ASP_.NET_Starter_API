using ASP_CORE_BASIC_NET_6_API.Repository.Models;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> GetAllAsync();
        Task<Wallet?> GetAsync(int id);
        Task<Wallet> AddAsync(Wallet wallet);
        Task<Wallet?> UpdateAsync(Wallet wallet, int id);
        Task<bool> DeleteAsync(int id);
    }
}
