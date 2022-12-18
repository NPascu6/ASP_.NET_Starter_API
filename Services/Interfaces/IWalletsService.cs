using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IWalletService
    {
        Task<List<WalletDTO>> GetAllWallets();
        Task<WalletDTO?> GetWalletById(int id);
        Task<WalletDTO?> AddWallet(WalletDTO walletDTO, int userId);
        Task<WalletDTO?> UpdateWallet(WalletDTO userDTO, int id);
        Task<bool> DeleteWallet(int id);
        Task<bool> DeleteAllWallets();
    }
}
