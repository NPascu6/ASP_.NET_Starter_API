using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUsersService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
    }
}
