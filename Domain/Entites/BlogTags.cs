namespace Domain.Entites;
public class BlogTags
{
    public Blog Blog { get; set; }
    public Guid BlogId { get; set; }

    public Tag Tag { get; set; }
    public int TagId { get; set; }
}
