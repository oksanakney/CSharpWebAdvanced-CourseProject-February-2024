using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.ViewModels.Comment;

namespace NebulaNewsSystem.Services.Data
{
    public class CommentService : ICommentService
    {
        public Task<AddCommentViewModel> WriteCommentByArticleIdAsync(string articleId, string readerId)
        {
            throw new NotImplementedException();
        }
    }
}
