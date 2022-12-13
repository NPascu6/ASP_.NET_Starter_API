using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DBContextBase _dbContext;

        public AssetRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }


        public IEnumerable<Asset> GetAll()
        {
            return _dbContext.Assets.ToList();
        }

        public Asset? Get(int id)
        {
            return _dbContext.Assets.FirstOrDefault(a => a.AssetId == id);
        }
    }
}
