using System.Threading.Tasks;

namespace WebSignalR.Core.Services
{
    public interface ICheckOutUserService
    {
        Task RunAsync();
        Task StopAsync();
    }
}