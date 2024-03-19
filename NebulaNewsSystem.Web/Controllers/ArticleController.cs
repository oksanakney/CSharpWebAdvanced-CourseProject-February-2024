using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NebulaNewsSystem.Web.Controllers
{
    //Because only author can do crud operations on articles
    [Authorize]
    public class ArticleController : Controller
    {
    //   [AllowAnonymous]
    //   public async Task<IActionResult> All()
    //    {

    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> Add()
    //    {

    //    }
    }
}
