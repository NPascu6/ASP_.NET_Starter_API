using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IAssetsService
    {
        Task<List<AssetDTO>> GetAllAssets();
        Task<AssetDTO?> GetAssetById(int id);
        Task<AssetDTO?> AddAsset(AssetDTO assetDTO, int walletId);
        Task<AssetDTO?> UpdateAsset(AssetDTO assetDTO, int id);
        Task<bool> DeleteAsset(int id);
    }
}
