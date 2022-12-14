using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<Wallet> AddAsync(Wallet wallet)
        {
            await _dbContext.Wallets.AddAsync(wallet);
            await _dbContext.SaveChangesAsync();

            return wallet;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wallet = _dbContext.Wallets.FirstOrDefault(u => u.WalletId == id);

            if (wallet != null)
            {
                _dbContext.Wallets.Remove(wallet);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Wallet?> UpdateAsync(Wallet wallet, int id)
        {
            var existing = await _dbContext.Wallets.FirstOrDefaultAsync(u => u.WalletId == id);
            if (existing != null)
            {
                existing.WalletName = wallet.WalletName;

                _dbContext.Wallets.Update(existing);
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
