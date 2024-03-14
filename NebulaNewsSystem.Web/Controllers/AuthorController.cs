using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NebulaNewsSystem.Web.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Become()
        {
            return  View();
        }
    }
}
