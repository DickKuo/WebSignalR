using System;
using System.Linq;
using WebSignalR.Core.Define;
using System.Threading.Tasks;
using WebSignalR.Core.Models;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace WebSignalR.Core.Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IServiceProvider _provider;
        private readonly IMemoryCache _memoryCache;
        private ConcurrentDictionary<string, UserInfo> _hubCallerContextDict;

        public PermissionService(IServiceProvider provider)
        {
            _provider = provider;
            _memoryCache = _provider.GetRequiredService<IMemoryCache>();
            _hubCallerContextDict = new ConcurrentDictionary<string, UserInfo>();
        }

        public async Task<BaseResponse<bool>> CheckoutUsersAsync()
        { 
            var onlines = await this.GetOnlineAsync();

            foreach (var item in onlines.Response)
            {
                if (item.ExpiryDate <= DateTime.Now)
                {
                    return await this.KillAsync(new KillRequest()
                    {
                        UserId = item.UserId
                    });
                }
            }

            return new BaseResponse<bool>()
            {
                ErrorCode = ErrorCodes.Success,
                Response = true
            };
        }

        public async Task<BaseResponse<IEnumerable<UserInfo>>> GetOnlineAsync()
        {            
            return new BaseResponse<IEnumerable<UserInfo>>()
            {
                ErrorCode = ErrorCodes.Success,
                Response = _hubCallerContextDict.Values.ToList()
            };
        }

        /// <summary>
        /// 踢出玩家
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> KillAsync(KillRequest request)
        {
            return new BaseResponse<bool>()
            {
                ErrorCode = ErrorCodes.Success,
                Response = true
            };
        }

        public async Task<BaseResponse<bool>> LogInAsync(LogInRequest request)
        {
            if (!_hubCallerContextDict.ContainsKey(request.UserId))
            {
                _hubCallerContextDict.TryAdd(request.UserId, new UserInfo()
                {
                    UserId = request.UserId,
                    LoginTime = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMinutes(1),
                    Context = request.Context
                });
            }

            return new BaseResponse<bool>()
            {
                ErrorCode = ErrorCodes.Success,
                Response = true
            };
        }

        /// <summary>
        /// 玩家登出
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse<bool>> LogOutAsync(LogOutRequest request)
        {
            return await this.KillAsync(new KillRequest()
            {
                UserId = request.UserId
            });
        }
    }
}