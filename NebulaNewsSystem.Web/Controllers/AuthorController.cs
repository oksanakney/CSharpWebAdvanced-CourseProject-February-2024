using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Infrastructure.Extensions;
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
            // while writing extensions, check User -> ClaimsPrincipal
            string? userId = this.User.GetId();
            bool isAuthor = await this.authorService.AuthorExistsByReaderIdAsync(userId);
            if (isAuthor) 
            {
                TempData[ErrorMessage] = "You are already an author!";

                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
