using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace NebulaNewsSystem.Web.Data
{
    public class NebulaNewsDbContext : IdentityDbContext
    {
        public NebulaNewsDbContext(DbContextOptions<NebulaNewsDbContext> options)
            : base(options)
        {
        }
    }
}
