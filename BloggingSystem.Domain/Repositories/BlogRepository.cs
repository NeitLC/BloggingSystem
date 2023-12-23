using BloggingSystem.Domain.Context;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Models;

namespace BloggingSystem.Domain.Repositories;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    
    public BlogRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext)
    {
        
    }
    
}