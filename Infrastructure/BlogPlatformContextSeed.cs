using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class BlogPlatformContext
{
    // Database seeding
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        #region Adding tag
        modelBuilder.Entity<Tag>().HasData(
            new Tag
            {
                Id = 1,
                Name = "IOS",
            },
            new Tag
            {
                Id = 2,
                Name = "AR"
            },
            new Tag
            {
                Id = 3,
                Name = "Gazzda"
            });

        #endregion

        #region Adding blog

        modelBuilder.Entity<Blog>().HasData(
            new Blog(id: new Guid(g: "FAFC7E94-6B81-4B55-AE7E-7D542D727815"), slug: "augmented-reality-ios-application")
            {
                Title = "Augmented Reality iOS Application",
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                CreatedAt = DateTime.Now.AddDays(-4),
                UpdatedAt = DateTime.Now.AddDays(-1)
            },
            new Blog(id: new Guid(g: "FE7BCFEA-A650-4E18-979E-75C113C05908"), slug: "augmented-reality-ios-application-2")
            {
                Title = "Augmented Reality iOS Application 2",
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now
            },
            new Blog(id: new Guid(g: "2D5A1F3C-C149-4B3C-8EE9-6AAA0E870340"), slug: "augmented-reality-ios-application-3")
            {
                Title = "Augmented Reality iOS Application 3",
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                CreatedAt = DateTime.Now.AddDays(-6),
                UpdatedAt = DateTime.Now.AddDays(-2)
            }
        ); ;

        #endregion

        #region Adding BlogTag

        modelBuilder.Entity<BlogTags>().HasData(
            new BlogTags
            {
                BlogId = new Guid(g: "2D5A1F3C-C149-4B3C-8EE9-6AAA0E870340"),
                TagId = 1,
            },
            new BlogTags
            {
                BlogId = new Guid(g: "FAFC7E94-6B81-4B55-AE7E-7D542D727815"),
                TagId = 2
            });
        #endregion

        #region Adding Comments
        modelBuilder.Entity<Comment>().HasData(
            new Comment(id: new Guid(g: "552FB2D3-970F-4DE0-9DAF-1C7710C65224"), slug: "augmented-reality-ios-application-3")
            {
                Body = "Great blog.",
                BlogSlug = "augmented-reality-ios-application-3",
                CreatedAt = DateTime.Now.AddDays(-6),
                UpdatedAt = DateTime.Now.AddDays(-2),
                BlogId = new Guid(g: "FAFC7E94-6B81-4B55-AE7E-7D542D727815")
            },
            new Comment(id: new Guid(g: "8EDD0363-4708-4CBD-89FC-CD9591A54F13"), slug: "augmented-reality-ios-application")
            {
                Body = "Great grate blog.",
                BlogSlug = "augmented-reality-ios-application",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now,
                BlogId = new Guid(g: "FAFC7E94-6B81-4B55-AE7E-7D542D727815")

            }
            );
        #endregion
    }
}
