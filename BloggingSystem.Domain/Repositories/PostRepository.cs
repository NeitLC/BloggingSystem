using BloggingSystem.Domain.Context;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Models;

namespace BloggingSystem.Domain.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext)
    {
        
    }
}