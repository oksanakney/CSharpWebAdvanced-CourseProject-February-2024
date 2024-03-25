using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Services.Data.Models.Articles;
using NebulaNewsSystem.Web.Data.Migrations;
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
        private readonly IArticleService articleService;

        public ArticleController(ICategoryService categoryService, IAuthorService authorService, IArticleService articleService)
        {
            this.categoryService = categoryService;
            this.authorService = authorService;
            this.articleService = articleService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllArticlesQueryModel queryModel)
        {
            AllArticlesFilteredAndPagedServiceModel serviceModel =
                await this.articleService.AllAsync(queryModel);

            queryModel.Articles = serviceModel.Articles;
            queryModel.TotalArticles = serviceModel.TotalArticlesCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();

            return this.View(queryModel);
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

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<ArticleAllViewModel> myArticles = 
                new List<ArticleAllViewModel>();

            string userId = this.User.GetId()!;
            bool isUserAuthor = await this.authorService
                .AuthorExistsByReaderIdAsync(userId);
            if (!isUserAuthor)
            {
                string? authorId = 
                    await this.authorService.GetAuthorIdByUserIdAsync(userId);

                myArticles.AddRange(await this.articleService.AllByAuthorIdAsync(authorId!));
            }
            else 
            { 
                myArticles.AddRange(await this.articleService.AllByAuthorIdAsync(userId));
            }

            return View(myArticles);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool articleExists = await this.articleService
                .ExistsByIdAsync(id);
            if (!articleExists)
            {
                this.TempData[ErrorMessage] = "Article with a provided id does not exist!";

                return this.RedirectToAction("All", "Article");
            }

            bool isUserAuthor = await this.authorService
                .AuthorExistsByReaderIdAsync(this.User.GetId()!);
            if (!isUserAuthor) 
            {
                this.TempData[ErrorMessage] = "You must become an author in order to edit article info!";

                return RedirectToAction("Become", "Author");
            }

            string? authorId = await this.authorService.GetAuthorIdByUserIdAsync(this.User.GetId()!);
            bool isAuthorPublisher = await this.articleService
                .IsAuthorWithIdPublisherOfArticleWithIdAsync(id, authorId!);
            if (!isAuthorPublisher) 
            {
                this.TempData[ErrorMessage] = "You must become the author who published the article you want to edit!";

                return this.RedirectToAction("Mine", "House");
            }

            ArticleFormModel formModel = await this.articleService
                .GetArticleForEditByIdAsync(id);
            formModel.Categories = await this.categoryService.AllCategoriesAsync();

            return this.View(formModel);      
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ArticleFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();
                return this.View(model);
            }

            bool articleExists = await this.articleService
                .ExistsByIdAsync(id);
            if (!articleExists)
            {
                this.TempData[ErrorMessage] = "Article with a provided id does not exist!";

                return this.RedirectToAction("All", "Article");
            }

            bool isUserAuthor = await this.authorService
                .AuthorExistsByReaderIdAsync(this.User.GetId()!);
            if (!isUserAuthor)
            {
                this.TempData[ErrorMessage] = "You must become an author in order to edit article info!";

                return RedirectToAction("Become", "Author");
            }

            string? authorId = await this.authorService.GetAuthorIdByUserIdAsync(this.User.GetId()!);
            bool isAuthorPublisher = await this.articleService
                .IsAuthorWithIdPublisherOfArticleWithIdAsync(id, authorId!);
            if (!isAuthorPublisher)
            {
                this.TempData[ErrorMessage] = "You must become the author who published the article you want to edit!";

                return this.RedirectToAction("Mine", "House");
            }
        }
    }
}
