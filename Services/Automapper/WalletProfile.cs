using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class WalletProfile: Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, Models.DTOs.WalletDTO>();
            CreateMap<Models.DTOs.WalletDTO, Wallet>();
        }
    }
}
