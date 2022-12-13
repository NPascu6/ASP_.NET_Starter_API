using ASP_CORE_BASIC_NET_6_API.Models.Domain;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IUserDetailsRepository
    {
        IEnumerable<UserDetails> GetAll();
        UserDetails? Get(int id);
        UserDetails? GetByUserId(int id);
    }
}
