using Microsoft.AspNetCore.Mvc;

namespace NebulaNewsSystem.Web.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
