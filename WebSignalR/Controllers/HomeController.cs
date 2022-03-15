using Microsoft.AspNetCore.Mvc; 

namespace WebSignalR
{    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }         
    }
}
