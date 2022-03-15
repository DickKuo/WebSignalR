using System.Collections.Generic;
using System.Threading.Tasks;
using WebSignalR.Core.Models;

namespace WebSignalR.Core.Services
{
    public interface IPermissionService
    {
        Task<BaseResponse<bool>> LogOutAsync(LogOutRequest request);

        Task<BaseResponse<bool>> LogInAsync(LogInRequest request);

        Task<BaseResponse<IEnumerable<UserInfo>>> GetOnlineAsync();

        Task<BaseResponse<bool>> KillAsync(KillRequest request);

        Task<BaseResponse<bool>> CheckoutUsersAsync();
    }
}