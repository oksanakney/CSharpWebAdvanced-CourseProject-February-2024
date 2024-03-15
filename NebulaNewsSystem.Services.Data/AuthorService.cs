using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Data;
using NebulaNewsSystem.Web.ViewModels.Author;

namespace NebulaNewsSystem.Services.Data
{
    public class AuthorService : IAuthorService
    {
        private readonly NebulaNewsDbContext dbContext;
        public AuthorService(NebulaNewsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public async Task<bool> AuthorExistsByReaderIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Authors
                .AnyAsync(au => au.ReaderId == userId);

            return result;
        }

        public async Task<bool> AuthorExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                .Authors
                .AnyAsync(au => au.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task Create(string userId, BecomeAuthorFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasCommentsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
