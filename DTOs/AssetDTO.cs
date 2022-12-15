namespace ASP_CORE_BASIC_NET_6_API.Models.DTOs
{
    public class AssetDTO
    {
        public int AssetId { get; set; }
        public int WalletId { get; set; }
        public string? AssetName { get; set; }
        public double? AssetQuantity { get; set; }
    }
}
