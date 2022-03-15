using Microsoft.AspNet.SignalR.Hubs;

namespace WebSignalR.Core.Models
{
    public class LogInRequest
    {
        public string UserId { get; set;}
           
        public HubCallerContext Context { get; set; }
    }
}