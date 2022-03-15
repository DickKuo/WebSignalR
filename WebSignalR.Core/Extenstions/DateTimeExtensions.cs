using System; 

namespace WebSignalR.Core.Extenstions
{
    public static class DateTimeExtensions
    {
        public static string ToStringYYYYMMSS( this DateTime obj)
        {
            return obj.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
