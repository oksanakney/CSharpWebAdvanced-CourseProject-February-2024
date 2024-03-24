using Microsoft.AspNetCore.Mvc;

namespace NebulaNewsSystem.Web.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
