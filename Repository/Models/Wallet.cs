using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Repository.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; }
        public string? WalletName { get; set; }

        public int UserDetailsId { get; set; }

        [ForeignKey(nameof(UserDetailsId))]
        public UserDetails? UserDetails { get; set; }

        public IEnumerable<Asset> Assets { get; set; }
    }
}
