using Microsoft.AspNetCore.SignalR;
using System; 
using System.Threading.Tasks;
using WebSignalR.Core.Models;
using WebSignalR.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WebSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IServiceProvider _provider;
        private readonly IPermissionService _permissionService;
        private readonly ICheckOutUserService _checkOutUserService;

        public ChatHub(IServiceProvider provider)
        {
            _provider = provider;
            _permissionService = provider.GetRequiredService<IPermissionService>();
            _checkOutUserService = provider.GetRequiredService<ICheckOutUserService>();
        }

        public async Task SendMessage(string user, string message)
        {  
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task LoginAysnc(string user, string message)
        {
            await _permissionService.LogInAsync(new LogInRequest()
            {
                UserId = user
            });
        }

        public async Task LogOutAysnc(string user, string message)
        {
            var temp = Context.ConnectionId;

            await _checkOutUserService.StopAsync();
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var temo = this.Context.User.Identity.IsAuthenticated;
            return base.OnDisconnectedAsync(exception);
        }
    }
}