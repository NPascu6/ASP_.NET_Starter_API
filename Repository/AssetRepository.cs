using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DBContextBase _dbContext;

        public AssetRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }


        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _dbContext.Assets.ToListAsync();
        }

        public async Task<Asset?> GetAsync(int id)
        {
            return await _dbContext.Assets.FirstOrDefaultAsync(a => a.AssetId == id);
        }
    }
}
