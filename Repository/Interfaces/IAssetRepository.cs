using ASP_CORE_BASIC_NET_6_API.Repository.Models;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset?> GetAsync(int id);
        Task<Asset> AddAsync(Asset asset);
        Task<Asset?> UpdateAsync(Asset asset, int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAllAsync();

    }
}
