using ASP_CORE_BASIC_NET_6_API.Models.Domain;

namespace ASP_CORE_BASIC_NET_6_API.Models.DTOs
{
    public class UserDTO
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Email { get; set; }
        public UserDetailsDTO? UserDetails { get; set; }
    }
}
