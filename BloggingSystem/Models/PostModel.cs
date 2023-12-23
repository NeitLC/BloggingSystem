using System.ComponentModel.DataAnnotations;

namespace BloggingSystem.Models;

public class PostModel
{
   public string? Title { get; set; }
   
   public string? Content { get; set; }
   
   [Required]
   public string? BlogId { get; set; }
   
   [Required]
   public string? UserId { get; set; }
   
   // public IEnumerable<Comment> Comments { get; set; }
}