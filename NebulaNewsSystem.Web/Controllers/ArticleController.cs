using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Infrastructure.Extensions;
using NebulaNewsSystem.Web.ViewModels.Article;
using static NebulaNewsSystem.Common.NotificationMessagesConstants;

namespace NebulaNewsSystem.Web.Controllers
{
    //Because only author can do crud operations on articles
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;

        public ArticleController(ICategoryService categoryService, IAuthorService authorService)
        {
            this.categoryService = categoryService;
            this.authorService = authorService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //We ima user zawoto e authorized
            bool isAuthor =
                await this.authorService.AuthorExistsByReaderIdAsync(this.User.GetId()!);
            if (!isAuthor)
            {
                TempData[ErrorMessage] = "You must become an author in order to add new houses!";

                return this.RedirectToAction("Become", "Author");
            }

            ArticleFormModel formModel = new ArticleFormModel()
            //object initializer
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return View(formModel);
        }
    }
}
