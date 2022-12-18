using Microsoft.AspNetCore.SignalR;

namespace ASP_CORE_BASIC_NET_6_API.Helpers
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection?.User?.Identity?.Name;
        }
    }
}
