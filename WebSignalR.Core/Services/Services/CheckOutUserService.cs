using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WebSignalR.Core.Extenstions;

namespace WebSignalR.Core.Services
{
    public class CheckOutUserService :  ICheckOutUserService
    {
        private IServiceProvider _provider;
        private static IPermissionService _permissionService; 
        CancellationTokenSource ts = new CancellationTokenSource();
        CancellationToken ct;

        public CheckOutUserService(IServiceProvider provider) {
            _provider = provider;
            _permissionService = provider.GetRequiredService<IPermissionService>(); 
            ct = ts.Token; 
        }

        public async Task RunAsync()
        {
            Console.WriteLine($"Task Start :{ DateTime.Now.ToStringYYYYMMSS()}");
            await Task.Factory.StartNew(() =>
            { 
                while (true)
                {
                    Console.WriteLine($"{ DateTime.Now.ToStringYYYYMMSS()}");
                    _permissionService.CheckoutUsersAsync().ConfigureAwait(false);
                    Thread.Sleep(1000);
                    if (ct.IsCancellationRequested)
                    {
                        Console.WriteLine($"Task Canceled : {DateTime.Now.ToStringYYYYMMSS()}");
                        break;
                    } 
                }
            }, ct);
        }

        public async Task StopAsync()
        {
            ts.Cancel(); 
            Console.WriteLine($"Task Stop :{ DateTime.Now.ToStringYYYYMMSS()}");
        } 
    }
}