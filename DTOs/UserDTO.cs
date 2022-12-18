using ASP_CORE_BASIC_NET_6_API.Validators;

namespace ASP_CORE_BASIC_NET_6_API.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? ConnectionId { get; set; }
        public bool? IsConnected { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public UserDetailsDTO? UserDetails { get; set; }
    }
}
