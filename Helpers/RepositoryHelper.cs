using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repositories;

namespace ASP_CORE_BASIC_NET_6_API.Helpers
{
    public static class RepositoryHelper
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<IAssetRepository, AssetRepository>();
        }
    }
}
