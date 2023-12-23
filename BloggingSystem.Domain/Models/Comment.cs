namespace BloggingSystem.Domain.Models;

public class Comment : BaseEntity
{
    public string? Content { get; set; }
    
    public string? UserId { get; set; }
    
    public User? User { get; set; }
    
    public string? PostId { get; set; }
    
    public Post? Post { get; set; }
    
    public DateTime? DateOfCreation { get; set; } = DateTime.UtcNow;
}