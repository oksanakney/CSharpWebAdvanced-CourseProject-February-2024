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
                .AnyAsync(au => au.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> AuthorExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                .Authors
                .AnyAsync(au => au.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> AuthorExistsByEmailAddressAsync(string emailAddress)
        {
            bool result = await this.dbContext
                .Authors
                .AnyAsync(au => au.EmailAddress == emailAddress);

            return result;
        }


        public async Task<bool> HasCommentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
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
                EmailAddress = model.EmailAddress,
                UserId = userId
            };

            await this.dbContext.Authors.AddAsync(newAuthor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string?> GetAuthorIdByUserIdAsync(string userId)
        {
            Author? author = await this.dbContext
                .Authors
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);
            if (author == null)
            {
                return string.Empty;
            }

            return author.Id.ToString();
        }
    }
}
