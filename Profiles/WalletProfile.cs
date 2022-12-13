using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class WalletProfile: Profile
    {
        public WalletProfile()
        {
            CreateMap<Models.Domain.Wallet, Models.DTOs.WalletDTO>();
        }
    }
}
