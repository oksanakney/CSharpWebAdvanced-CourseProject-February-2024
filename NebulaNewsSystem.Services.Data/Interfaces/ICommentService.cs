using NebulaNewsSystem.Web.ViewModels.Comment;

namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface ICommentService
    {
        Task<AddCommentViewModel> WriteCommentByArticleIdAsync(string articleId, string readerId);
    }
}
