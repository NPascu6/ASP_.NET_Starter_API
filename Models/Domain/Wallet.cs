using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Models.Domain
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; }
        public string? WalletName { get; set; }
        public IEnumerable<Asset>? Assets { get; set; }
    }
}
