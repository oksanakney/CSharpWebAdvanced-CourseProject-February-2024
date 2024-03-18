using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;
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

        public async Task<bool> HasCommentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) 
            {
                return false;
            }

            return user.CommentedArticles.Any();
        }

        public async Task Create(string userId, BecomeAuthorFormModel model)
        {
            Author newAuthor = new Author()
            {
                PhoneNumber = model.PhoneNumber,
                ReaderId = userId
            };

            await this.dbContext.Authors.AddAsync(newAuthor);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
