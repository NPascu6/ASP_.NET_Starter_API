using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class AssetProfile: Profile
    {
        public AssetProfile()
        {
            CreateMap<Models.Domain.Asset, Models.DTOs.AssetDTO>();
        }
    }
}
