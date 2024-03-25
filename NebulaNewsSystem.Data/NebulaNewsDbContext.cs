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

    public class NebulaNewsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
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
            //builder
            //     .Entity<ApplicationUser>()
            //     .Property(e => e.UserName)
            //     .ValueGeneratedOnAdd();

            builder.Entity<Author>()
                .HasOne(a => a.Reader)
                .WithMany()
                .HasForeignKey(a => a.ReaderId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Alter the column
            builder.Entity<Author>()
                .Property(a => a.ReaderId)
                .IsRequired(false) // or true depending on your requirements
                .HasColumnType("uniqueidentifier");

            // Recreate the foreign key constraint
            builder.Entity<Author>()
                .HasOne(a => a.Reader)
                .WithMany()
                .HasForeignKey(a => a.ReaderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany()
                .HasForeignKey(c => c.CommenterId)
                .OnDelete(DeleteBehavior.Restrict); // Or DeleteBehavior.Cascade depending on your requirements

            // Alter the column
            builder.Entity<Comment>()
                .Property(c => c.CommenterId)
                .IsRequired(false) // Depending on your requirements
                .HasColumnType("uniqueidentifier");

            // Recreate the foreign key constraint
            builder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany()
                .HasForeignKey(c => c.CommenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore<Comment>();
            builder.Entity<Comment>()
                .HasOne(c => c.Commenter)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommenterId);            

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
