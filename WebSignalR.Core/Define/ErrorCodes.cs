using System.ComponentModel;

namespace WebSignalR.Core.Define
{
    public enum ErrorCodes
    {
        [Description("未定義")]
        None = 0,

        [Description("成功")]
        Success = 200
    }
}