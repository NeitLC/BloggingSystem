using BloggingSystem.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Domain.Context;

public class ApplicationDbContext: IdentityDbContext<User>
{
    public DbSet<Blog>? Blogs { get; set; }
    
    public DbSet<Comment>? Comments { get; set; }
    
    public DbSet<Post>? Posts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}