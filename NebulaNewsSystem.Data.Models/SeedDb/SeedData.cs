using Microsoft.AspNetCore.Identity;
using System.Data.Common;

namespace NebulaNewsSystem.Data.Models.SeedDb
{
    internal class SeedData
    {
        public IdentityUser AuthorUser { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AuthorUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };
            AuthorUser.PasswordHash = hasher.HashPassword(AuthorUser, "agent123");
        }

    }
}
