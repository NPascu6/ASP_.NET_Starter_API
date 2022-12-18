using ASP_CORE_BASIC_NET_6_API.Models.DTOs;

namespace ASP_CORE_BASIC_NET_6_API.Services.Interfaces
{
    public interface IUserDetailsService
    {
        Task<List<UserDetailsDTO>> GetAllUserDetails();
        Task<UserDetailsDTO?> GetUserDetailsById(int id);
        Task<UserDetailsDTO?> GetUserDetailsByUserId(int id);
        Task<UserDetailsDTO?> AddUserDetails(UserDetailsDTO userDetailsDTO, int userId);
        Task<UserDetailsDTO?> UpdateUserDetails(UserDetailsDTO userDetailsDTO, int userId);
        Task<bool> DeleteUserDetails(int id);
        Task<bool> DeleteAllUserDetails();
    }
}
