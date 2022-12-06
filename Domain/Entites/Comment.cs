using Domain.Primitives;

namespace Domain.Entites;

public sealed class Comment : Entity
{
    public Comment(Guid id, string slug) : base(id, slug)
    {
    }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Body { get; set; }
    public Blog Blog { get; set; }
    public Guid BlogId { get; set; }
    public string BlogSlug { get; set; }

}
