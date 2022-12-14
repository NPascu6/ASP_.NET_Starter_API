using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DBContextBase _dbContext;

        public WalletRepository(DBContextBase dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<IEnumerable<Wallet>> GetAllAsync()
        {
            return await _dbContext.Wallets
                .Include(w => w.Assets)
                .ToListAsync();
        }

        public async Task<Wallet?> GetAsync(int id)
        {
            return await _dbContext.Wallets
                .Include(w => w.Assets)
                .FirstOrDefaultAsync(w => w.WalletId == id);
        }

        public Task<Wallet> AddAsync(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> UpdateAsync(Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
