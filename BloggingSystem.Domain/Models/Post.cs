namespace BloggingSystem.Domain.Models;

public class Post : BaseEntity
{
    public string? Title { get; set; }
    
    public string? Content { get; set; }
    
    public DateTime? DateOfCreation { get; set; } = DateTime.UtcNow;

    public string? BlogId { get; set; }
    
    public Blog? Blog { get; set; }
    public string? UserId { get; set; }
    
    public User? User { get; set; }

    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
}