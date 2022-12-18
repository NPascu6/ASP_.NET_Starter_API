using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, Models.DTOs.UserDTO>();
            CreateMap<Models.DTOs.UserDTO, User>();
        }
    }
}
