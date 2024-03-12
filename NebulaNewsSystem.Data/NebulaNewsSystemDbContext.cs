using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Models;

namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsSystemDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public NebulaNewsSystemDbContext(DbContextOptions<NebulaNewsSystemDbContext> options)
            : base(options)
        {
            
        }
    }
}
