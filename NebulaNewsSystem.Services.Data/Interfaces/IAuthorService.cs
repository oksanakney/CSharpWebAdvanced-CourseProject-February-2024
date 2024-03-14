namespace NebulaNewsSystem.Services.Data.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AuthorExistsByReaderIdAsync(string userId);
    }
}
