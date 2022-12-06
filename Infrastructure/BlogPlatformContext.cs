using Domain.Entites;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class BlogPlatformContext : DbContext
{
    public BlogPlatformContext(DbContextOptions<BlogPlatformContext> options)
       : base(options)
    {

    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tag { get; set; }

    public new DbSet<TEntity> Set<TEntity>()
       where TEntity : Entity => base.Set<TEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BlogPlatformDb;Integrated Security = true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogTags>().HasKey(b => new { b.BlogId, b.TagId });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.Slug)
            .IsRequired()
            .HasMaxLength(100);

            entity.Property(e => e.Title)
           .IsRequired()
           .HasMaxLength(50);

            entity.Property(e => e.Description)
           .IsRequired()
           .HasMaxLength(250);

            entity.Property(e => e.Body)
           .IsRequired()
           .HasMaxLength(250);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
