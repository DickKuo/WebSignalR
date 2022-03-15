using Microsoft.AspNet.SignalR.Hubs;

namespace WebSignalR.Core.Models
{
    public class LogOutRequest
    {
        public string UserId { get; set; }

        public HubCallerContext Context { get; set; }
    }
}