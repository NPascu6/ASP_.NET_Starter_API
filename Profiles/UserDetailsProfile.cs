using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserDetailsProfile : Profile
    {
        public UserDetailsProfile()
        {
            CreateMap<Models.Domain.UserDetails, Models.DTOs.UserDetailsDTO>();
        }
    }
}
