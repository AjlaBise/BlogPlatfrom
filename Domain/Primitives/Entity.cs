namespace Domain.Primitives;

public abstract class Entity
{
    protected Entity(Guid id, string slug)
    {
        Id = id;
        Slug = slug;
    }

    public Guid Id { get; set; }
    public string Slug { get; set; }
}