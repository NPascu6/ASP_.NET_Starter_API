using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetsService(IAssetRepository repository, IMapper mapper)
        {
            this._assetRepository = repository;
            this._mapper = mapper;
        }

        public async Task<List<AssetDTO>> GetAllAssets()
        {
            try
            {
                var allAssets = await _assetRepository.GetAllAsync();
                var allAssetsDTOs = _mapper.Map<List<AssetDTO>>(allAssets);

                return allAssetsDTOs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return new List<AssetDTO>();
            }
        }

        public async Task<AssetDTO?> GetAssetById(int id)
        {
            try
            {
                var asset = await _assetRepository.GetAsync(id);

                if (asset == null) return null;
                else
                {
                    var assetDTO = _mapper.Map<AssetDTO>(asset);
                    return assetDTO;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
          
        }

        public async Task<AssetDTO?> AddAsset(AssetDTO assetDTO, int walletId)
        {
            try
            {
                var asset = _mapper.Map<Asset>(assetDTO);

                asset.WalletId = walletId;
                var addedAsset = await _assetRepository.AddAsync(asset);

                if (addedAsset == null) return null;
                else
                {
                    var added = _mapper.Map<AssetDTO>(addedAsset);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<AssetDTO?> UpdateAsset(AssetDTO userDetailsDTO, int id)
        {
            try
            {
                var asset = _mapper.Map<Asset>(userDetailsDTO);

                var updated = await _assetRepository.UpdateAsync(asset, id);

                if (updated == null) return null;
                else
                {
                    var updatedDTO = _mapper.Map<AssetDTO>(updated);
                    return updatedDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteAsset(int id)
        {
            try
            {
                return await _assetRepository.DeleteAsync(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
