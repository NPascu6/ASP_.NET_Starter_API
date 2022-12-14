namespace ASP_CORE_BASIC_NET_6_API.Models.DTOs
{
    public class UserDetailsDTO
    {
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? BirthDate { get; set; }
        public UserRoleDTO? UserRole { get; set; }
        public WalletDTO? Wallet { get; set; }
    }
}
