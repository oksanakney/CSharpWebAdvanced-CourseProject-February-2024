using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Infrastructure.Extensions;
using NebulaNewsSystem.Web.ViewModels.Author;
using static NebulaNewsSystem.Common.NotificationMessagesConstants;

namespace NebulaNewsSystem.Web.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();
            bool isAuthor = await this.authorService.AuthorExistsByReaderIdAsync(userId);
            if (isAuthor)
            {
                this.TempData[ErrorMessage] = "You are already an author!";

                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAuthorFormModel model)
        {
            string? userId = this.User.GetId();
            bool isAuthor = await this.authorService.AuthorExistsByReaderIdAsync(userId);
            if (isAuthor)
            {
                this.TempData[ErrorMessage] = "You are already an author!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.authorService
                .AuthorExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken) 
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Author with the provided phone number already exists!");            
            }

            if (this.ModelState.IsValid) 
            { 
                return this.View(model);
            }

            //bool userHasComments = await this.authorService
            //    .HasCommentsByUserIdAsync(userId);
            try
            {
                await this.authorService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected erroe occurred while registering you as an author! Please try again later or conatct administrator.";

                return RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "Article");
        }
    }
}
