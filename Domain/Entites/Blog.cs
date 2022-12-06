using Domain.Primitives;

namespace Domain.Entites;

public class Blog : Entity
{
    public Blog(Guid id, string slug) : base(id, slug)
    {
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public virtual ICollection<Tag> Tag { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
