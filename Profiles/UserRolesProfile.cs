using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserRolesProfile: Profile
    {
        public UserRolesProfile()
        {
            CreateMap<Models.Domain.UserRole, Models.DTOs.UserRoleDTO>();
        }
    }
}
