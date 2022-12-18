using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class AssetProfile: Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, Models.DTOs.AssetDTO>();
            CreateMap<Models.DTOs.AssetDTO, Asset>();
        }
    }
}
