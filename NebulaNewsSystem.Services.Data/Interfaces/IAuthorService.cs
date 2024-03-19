using NebulaNewsSystem.Web.ViewModels.Author;

namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AuthorExistsByReaderIdAsync(string userId);

        Task<bool> AuthorExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> AuthorExistsByEmailAddressAsync(string emailAddress);

        Task<bool> HasCommentsByUserIdAsync(string userId);

        Task Create(string userId, BecomeAuthorFormModel model);
    }
}
