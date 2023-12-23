namespace BloggingSystem.Domain.Models;

public class Blog : BaseEntity
{
    public string? Title { get; set; }
    
    public DateTime? DateOfCreation { get; set; } = DateTime.UtcNow;
    
    public string? UserId { get; set; }
    
    public User User { get; set; }

    public IEnumerable<Post> Posts { get; set; }
}