﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NebulaNewsSystem.Web.Data;

#nullable disable

namespace NebulaNewsSystem.Web.Data.Migrations
{
    [DbContext(typeof(NebulaNewsDbContext))]
    partial class NebulaNewsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("550f78bf-9c45-4fa1-9a1e-4af3a5192be6"),
                            AuthorId = new Guid("439455a8-590b-4fd3-a3f6-5cf16729dbb2"),
                            CategoryId = 7,
                            Content = "A 17-year-old unlicensed driver of a Mercedes was detained last night by Dupnitsa's policemen. They carried out the inspection in the area of Sapareva Banya, and also found that the inspected car had registration plates issued for another vehicle. A quick police investigation was initiated in the Dupnitsa Intelligence Department, the prosecutor's office was notified.",
                            ImageUrl = "https://i.id24.bg/i/1616547.jpg",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A 17-year-old who drove a Mercedes both without a license and with fake license plates arrested"
                        },
                        new
                        {
                            Id = new Guid("49cde94c-3f90-4f95-8e91-a751aa2b7af4"),
                            AuthorId = new Guid("439455a8-590b-4fd3-a3f6-5cf16729dbb2"),
                            CategoryId = 10,
                            Content = "The results of the competitions for principals of three Dupnitsa's schools are known now. Lyubomir Georgiev was elected as the director of \"Hristo Botev\" Profesional Gymnasium. He is a physical education teacher, baseball coach and former city councilman. The incumbent Gergana Milenkova dropped out of the race for the post. In head of secondary language school \"St. Paisiy Hilendarski\" remains Anelia Yordanova. She took over the leadership of the largest drilling school two years ago until a competition was held. Director of General Educational School \"St. Kliment Ohridski\" remains Juliana Borisova, who was the only candidate.",
                            ImageUrl = "https://static.bnr.bg/gallery/cr/3ae7c802129b9a9ae5af2da27e6a183a.jpg",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The results of the competitions for principals of schools in Dupnitsa are known"
                        },
                        new
                        {
                            Id = new Guid("3c74cdaa-71b0-4789-89e0-93c72fd2e8a9"),
                            AuthorId = new Guid("439455a8-590b-4fd3-a3f6-5cf16729dbb2"),
                            CategoryId = 1,
                            Content = "The transformation of the mineral water borehole in the village of Bistrica into an object of primary importance for the municipality will be the subject of debate at an extraordinary session in Dupnitsa. The report was entered by the councilor from \"Voice of the People\" Gichka Mihailova. We recall that she would alarm that the firm involved in the study was considering a withdrawal.",
                            ImageUrl = "https://4vlast-bg.com/wp-content/uploads/2023/12/403389284_682223740702741_5157933701577735441_n.jpg",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The municipal council of Dupnitsa meets because of the mineral water in Bistritsa"
                        });
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReaderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ReaderId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Politics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Business and Economy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Health and Wellness"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Entertainment and celebrities"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Science and Environment"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Technology"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Culture and Lifestyle"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Opinion and Editorial"
                        });
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Comment", b =>
                {
                    b.Property<Guid>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommenterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 3, 23, 20, 55, 24, 143, DateTimeKind.Utc).AddTicks(8836));

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommenterId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            CommentId = new Guid("53e508ee-3a15-4d7a-868a-00c38be79b84"),
                            ArticleId = new Guid("49cde94c-3f90-4f95-8e91-a751aa2b7af4"),
                            CommenterId = "247929cd-14da-4c78-bcc7-92fb93e300a1",
                            Content = "Dobre e taka, triabva da se vkara malko disciplina v gimnazijata",
                            CreationDate = new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(975)
                        },
                        new
                        {
                            CommentId = new Guid("1ce4973f-a458-4777-ac31-9032bd11f426"),
                            ArticleId = new Guid("550f78bf-9c45-4fa1-9a1e-4af3a5192be6"),
                            CommenterId = "20cd7080-3221-4b5e-96c9-f6ebd93555de",
                            Content = "emi za tova se praviat tolkova katastrofi, triabva da se vzemat merki",
                            CreationDate = new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(982)
                        },
                        new
                        {
                            CommentId = new Guid("a57e0fc2-96d6-41e8-ac14-aaf5f91872b4"),
                            ArticleId = new Guid("3c74cdaa-71b0-4789-89e0-93c72fd2e8a9"),
                            CommenterId = "5c65b87d-ab20-4314-bf26-4c7dbcca0924",
                            Content = "Bravo na Gi4ka, da gi razkara oti stanali sa mnogo nagli",
                            CreationDate = new DateTime(2024, 3, 23, 20, 55, 24, 144, DateTimeKind.Utc).AddTicks(988)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<string>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Article", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", null)
                        .WithMany("CommentedArticles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("NebulaNewsSystem.Data.Models.Author", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NebulaNewsSystem.Data.Models.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Author", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Comment", b =>
                {
                    b.HasOne("NebulaNewsSystem.Data.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NebulaNewsSystem.Data.Models.ApplicationUser", "Commenter")
                        .WithMany()
                        .HasForeignKey("CommenterId");

                    b.Navigation("Article");

                    b.Navigation("Commenter");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("CommentedArticles");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Author", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("NebulaNewsSystem.Data.Models.Category", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
