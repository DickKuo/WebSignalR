using System.ComponentModel;

namespace WebSignalR.Core.Define
{
    public enum WebSocketActions
    {
        [Description("未定義")]
        None = 0,

        [Description("登入")]
        Login = 1,

        [Description("登出")]
        LogOut = 2
    }
}