using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Profiles
{
    public class UserRolesProfile: Profile
    {
        public UserRolesProfile()
        {
            CreateMap<UserRole, Models.DTOs.UserRoleDTO>();
            CreateMap<Models.DTOs.UserRoleDTO, UserRole>();
        }
    }
}
