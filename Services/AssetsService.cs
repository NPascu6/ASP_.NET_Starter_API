using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
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

        public List<AssetDTO> GetAllAssets()
        {
            var allAssets = _assetRepository.GetAllAsync().Result;
            var allAssetsDTOs = _mapper.Map<List<AssetDTO>>(allAssets);

            return allAssetsDTOs;
        }

        public AssetDTO? GetAssetById(int id)
        {
            var asset = _assetRepository.GetAsync(id).Result;

            if(asset == null) return null;
            else
            {
                var assetDTO = _mapper.Map<AssetDTO>(asset);
                return assetDTO;
            }
        }
    }
}
