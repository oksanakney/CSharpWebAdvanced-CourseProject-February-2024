using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.ViewModels.Home;
using System.Diagnostics;

namespace NebulaNewsSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // Izdarpvam poslednite tri articles
        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel
                = await this.articleService.LastThreeArticlesAsync();
            return View(viewModel);
        }        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
