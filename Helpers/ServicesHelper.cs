using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services;

namespace ASP_CORE_BASIC_NET_6_API.Helpers
{
    public static class ServicesHelper
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IAssetsService, AssetsService>();
            builder.Services.AddScoped<IUserRolesService, UserRolesService>();
            builder.Services.AddScoped<IWalletService, WalletsService>();
            builder.Services.AddScoped<IUserDetailsService, UserDetailsService>();
        }
    }
}
