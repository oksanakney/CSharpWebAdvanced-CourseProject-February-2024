using Microsoft.AspNetCore.Mvc;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.ViewModels.Comment;
using static NebulaNewsSystem.Common.NotificationMessagesConstants;

namespace NebulaNewsSystem.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IArticleService articleService;
        public CommentController(ICommentService commentService, IArticleService articleService )
        {
            this.commentService = commentService;
            this.articleService = articleService;
        }

        /*Controller Actions:
        Create controller actions to handle comment-related operations such as adding a 
        - comment, 
        - view comments,
        - editing a comment, 
        - deleting a comment, etc. 
        These actions will interact with the comment model to perform the necessary operations.*/

        [HttpGet]
        public async Task<IActionResult> AddComment(string articleId, string readerId)
        {            
            bool articleExists = await this.articleService
                .ExistsByIdAsync(articleId);
            if (!articleExists) 
            {
                this.TempData[ErrorMessage] = "Article with a provided id does not exist!";

                return this.RedirectToAction("All", "Article");
            }
            
           AddCommentViewModel model = await this.commentService
                .WriteCommentByArticleIdAsync (articleId, readerId);
            //TODO  
           

            return View(model);
        }
    }
}
