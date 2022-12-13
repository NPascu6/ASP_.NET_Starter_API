using ASP_CORE_BASIC_NET_6_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_BASIC_NET_6_API.Data
{
    public class DBContextBase: DbContext
    {
        public DBContextBase(DbContextOptions<DBContextBase> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
