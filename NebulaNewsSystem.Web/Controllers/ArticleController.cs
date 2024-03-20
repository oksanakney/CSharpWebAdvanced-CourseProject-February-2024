using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Data.Migrations;
using NebulaNewsSystem.Web.Infrastructure.Extensions;
using NebulaNewsSystem.Web.ViewModels.Article;
using static NebulaNewsSystem.Common.NotificationMessagesConstants;
using static NebulaNewsSystem.Common.EntityValidationConstants.Article;
using System.Globalization;

namespace NebulaNewsSystem.Web.Controllers
{
    //Because only author can do crud operations on articles
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAuthorService authorService;
        private readonly IArticleService articleService;

        public ArticleController(ICategoryService categoryService, IAuthorService authorService, IArticleService articleService)
        {
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.articleService = articleService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            //TODO
            return this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //We ima user zawoto e authorized
            bool isAuthor =
                await this.authorService.AuthorExistsByReaderIdAsync(this.User.GetId()!);
            if (!isAuthor)
            {
                TempData[ErrorMessage] = "You must become an author in order to add new articles!";

                return this.RedirectToAction("Become", "Author");
            }

            ArticleFormModel formModel = new ArticleFormModel()
            //object initializer
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return View(formModel);      
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleFormModel model)
        {           

            bool isAuthor =
                await this.authorService.AuthorExistsByReaderIdAsync(this.User.GetId()!);
            if (!isAuthor)
            {
                TempData[ErrorMessage] = "You must become an author in order to add new articles!";

                return this.RedirectToAction("Become", "Author");
            }

            //Because user can change the category id from inspect page and submit error data
            bool categoryExists = 
                await this.categoryService.ExistsByIdAsync(model.CategoryId);
            if (!categoryExists) 
            {
                // Adding model error to ModelState automatically makes ModelState Invalid
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exist!");
            }
            
            // ModelState can be invalid for 2 reasons: category manipulation or not correct input
            // Http state protocol taka raboti 4e sme izgubili ve4e kategorii koito biaxme zaredili ->
            // Tria da gi zaredime nanovo
            // Tozi podhod ima i ime -> da o nameria
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            try
            {
                string? authorId = 
                    await this.authorService.GetAuthorIdByUserIdAsync(this.User.GetId()!);

                await this.articleService.CreateAsync(model, authorId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new article! Pease try again later or try to contact administrator.");
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            return this.RedirectToAction("All", "Article");
        }

    }
}
