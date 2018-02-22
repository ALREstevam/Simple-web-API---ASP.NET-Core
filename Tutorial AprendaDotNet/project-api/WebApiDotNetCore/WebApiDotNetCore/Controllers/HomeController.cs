using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNetCoreCSharp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}