using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IAssetsService
    {
        List<AssetDTO> GetAllAssets();
        AssetDTO GetAssetById(int id);
    }
}
