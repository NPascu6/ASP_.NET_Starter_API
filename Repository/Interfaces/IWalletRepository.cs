using ASP_CORE_BASIC_NET_6_API.Models.Domain;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        IEnumerable<Wallet> GetAll();
        Wallet? Get(int id);
    }
}
