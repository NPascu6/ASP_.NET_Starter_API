using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ASP_CORE_BASIC_NET_6_API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public ILogger<ChatHub> Logger { get; set; }
        private readonly IUsersService _usersService;

        public ChatHub(ILogger<ChatHub> logger, IUsersService usersService) : base()
        {
            Logger = logger;
            _usersService = usersService;
        }

        public override async Task OnConnectedAsync()
        {
            var email = Context?.User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            Logger.LogInformation($"OnConnectedAsync => Connection ID={Context?.ConnectionId} : User={email}");

            if (email != null)
            {
                await base.OnConnectedAsync();
                 
                var exists = await _usersService.GetByEmail(email);
                if (exists != null)
                {
                    UserDTO userToUpdate = new UserDTO()
                    {
                        Email = email,
                        ConnectionId = Context?.ConnectionId,
                        UserName = exists.UserName,
                        IsConnected = true
                    };

                    await _usersService.UpdateUser(userToUpdate, userToUpdate.UserId);
                }
                else
                {
                    UserDTO userToAdd = new UserDTO()
                    {

                        Email = email,
                        ConnectionId = Context?.ConnectionId,
                        UserName = Context?.User?.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                        IsConnected = true
                    };

                    await _usersService.AddUser(userToAdd);
                
                }

                List<UserDTO> users = await _usersService.GetAllUsers();
                await Clients.All.SendAsync("ReceiveMessage", $"{email}, connected to the chat.");
                await Clients.All.SendAsync("OnlineUsers", users);
            }
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Logger.LogInformation($"Disconnected");
            await this.Unsubscribe();
        }


        [Authorize("DomainRestricted")]
        public async Task SendMessage(string user, string message)
        {
            var email = Context?.User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            if (message.Contains("<script>"))
            {
                throw new HubException("Error: stop hacking!");
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task<bool> Unsubscribe()
        {
            var email = Context?.User?.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            Logger.LogInformation($"Unsubscribing, {Context?.ConnectionId} --- {email}");

            try
            {
                await Clients.All.SendAsync("ReceiveMessage", $"{email}, disconnected from the chat..");

                if (email != null)
                {
                    UserDTO userToRemove = new UserDTO()
                    {

                        Email = email,
                        ConnectionId = Context?.ConnectionId,
                        UserName = Context?.User?.Claims.FirstOrDefault(c => c.Type == "name")?.Value
                    };

                    var user = await _usersService.GetByEmail(email);

                    if (user != null)
                    {
                        var id = user.UserId;
                        await _usersService.DeleteUser(id);

                        var users = await _usersService.GetAllUsers();
                        await Clients.All.SendAsync("OnlineUsers", users);

                        Context?.Abort();
                        return true;
                    }
                    return false;
                }
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
