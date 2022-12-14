using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserDetailsProfile : Profile
    {
        public UserDetailsProfile()
        {
            CreateMap<UserDetails, Models.DTOs.UserDetailsDTO>();
            CreateMap<Models.DTOs.UserDetailsDTO, UserDetails>();
        }
    }
}
