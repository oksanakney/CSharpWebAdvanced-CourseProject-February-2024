using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NebulaNewsSystem.Data.Configurations.SeedCofiguration;
using NebulaNewsSystem.Data.Models;
using NebulaNewsSystem.Data.Models.Configuration;
using System.Reflection;
using System.Reflection.Emit;



namespace NebulaNewsSystem.Web.Data
{

    public class NebulaNewsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<string>, string>
    {
        private readonly bool seedDb;

        public NebulaNewsDbContext(DbContextOptions<NebulaNewsDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Weather> Weather { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Assembly configAssembly = Assembly.GetAssembly(typeof(NebulaNewsDbContext)) ??
            //                          Assembly.GetExecutingAssembly();
            //builder.ApplyConfigurationsFromAssembly(configAssembly);
            builder
                 .Entity<ApplicationUser>()
                 .Property(e => e.UserName)
                 .ValueGeneratedOnAdd();

            builder.Entity<Author>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);            

            builder.ApplyConfiguration(new ArticleEntityConfiguration());           
            builder.ApplyConfiguration(new CommentEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new SeedArticlesEntityConfiguration());
                builder.ApplyConfiguration(new SeedCategoriesEntityConfiguration());
                builder.ApplyConfiguration(new SeedCommentsEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
