using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<Asset> AddAsync(Asset asset)
        {
            await _dbContext.Assets.AddAsync(asset);
            await _dbContext.SaveChangesAsync();

            return asset;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asset = _dbContext.Assets.FirstOrDefault(u => u.AssetId == id);

            if (asset != null)
            {
                _dbContext.Assets.Remove(asset);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllAsync()
        {
            var allUsers = _dbContext.Assets.ToList();


            if (allUsers != null)
            {

                _dbContext.Assets.RemoveRange(allUsers);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Asset?> UpdateAsync(Asset asset, int id)
        {
            var existing = await _dbContext.Assets.FirstOrDefaultAsync(u => u.AssetId == id);
            if (existing != null)
            {
                existing.AssetName = asset.AssetName;
                existing.AssetQuantity = asset.AssetQuantity;

                _dbContext.Assets.Update(existing);
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
