using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Models.Domain
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserDetailsId { get; set; }

        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? BirthDate { get; set; }


        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User? User { get; set; }


        [ForeignKey(nameof(UserRoleId))]
        public int UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }


        [ForeignKey(nameof(WalletId))]
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
