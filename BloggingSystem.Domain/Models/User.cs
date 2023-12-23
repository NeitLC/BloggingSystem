using Microsoft.AspNetCore.Identity;

namespace BloggingSystem.Domain.Models;

public class User: IdentityUser
{
    public ICollection<Post>? Posts { get; set; }
    
    public ICollection<Blog>? Blogs { get; set; }
        
    public ICollection<Comment>? Comments { get; set; }
    
    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }
}