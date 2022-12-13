using ASP_CORE_BASIC_NET_6_API.Models.Domain;

namespace ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? Get(int id);
    }
}
