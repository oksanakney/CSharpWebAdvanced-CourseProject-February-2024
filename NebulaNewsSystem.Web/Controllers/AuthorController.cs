using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Infrastructure.Extensions;

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
                return this.BadRequest();
            }

            return this.View();
        }
    }
}
