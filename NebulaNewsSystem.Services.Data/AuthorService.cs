using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Services.Data.Interfaces;
using NebulaNewsSystem.Web.Data;

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
    }
}
