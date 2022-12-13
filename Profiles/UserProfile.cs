using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Models.Domain.User, Models.DTOs.UserDTO>()
                .ReverseMap();
        }
    }
}
