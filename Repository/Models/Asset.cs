﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_CORE_BASIC_NET_6_API.Repository.Models
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public double? AssetQuantity { get; set; }


        [ForeignKey(nameof(WalletId))]
        public int WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
