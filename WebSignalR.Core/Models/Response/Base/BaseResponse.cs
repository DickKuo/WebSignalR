using WebSignalR.Core.Define;

namespace WebSignalR.Core.Models
{
    public class BaseResponse<T>
    {
        public ErrorCodes ErrorCode { get; set; }

        public T Response { get; set;}
    }
}