using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUserRolesService
    {
        Task<List<UserRoleDTO>> GetAllUserRoles();
        Task<UserRoleDTO?> GetUserRoleById(int id);
        Task<UserRoleDTO?> AddUserRole(UserRoleDTO userRoleDTO);
        Task<UserRoleDTO?> UpdateUserRole(UserRoleDTO userRoleDTO, int id);
        Task<bool> DeleteUserRole(int id);
        Task<bool> DeleteAllUserRoles();
    }
}
