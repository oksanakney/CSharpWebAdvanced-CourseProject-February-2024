using Microsoft.AspNetCore.Mvc;

namespace NebulaNewsSystem.Web.Controllers
{
    public class CommentController : Controller
    {
        /*Controller Actions:
        Create controller actions to handle comment-related operations such as adding a 
        - comment, 
        - editing a comment, 
        - deleting a comment, etc. 
        These actions will interact with the comment model to perform the necessary operations.*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
