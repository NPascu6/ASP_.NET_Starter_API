using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUserDetailsService
    {
        List<UserDetailsDTO> GetAllUserDetails();
        UserDetailsDTO GetUserDetailsById(int id);
        UserDetailsDTO GetUserDetailsByUserId(int id);
    }
}
