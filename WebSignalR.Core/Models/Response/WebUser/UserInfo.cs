using Microsoft.AspNet.SignalR.Hubs;
using System;

namespace WebSignalR.Core.Models 
{
    public class UserInfo
    {
        public string UserId { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime ExpiryDate { get; set; }

        public HubCallerContext Context { get; set; }
    }
}