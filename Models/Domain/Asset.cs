using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Models.Domain
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public double? AssetQuantity { get; set; }

        public int WalletId { get; set; }

        [ForeignKey(nameof(WalletId))]
        public Wallet? Wallet { get; set; }
    }
}
