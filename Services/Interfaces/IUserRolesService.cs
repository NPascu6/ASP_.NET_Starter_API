using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUserRolesService
    {
        List<UserRoleDTO> GetAllUserRoles();
        UserRoleDTO GetUserRoleById(int id);
    }
}
