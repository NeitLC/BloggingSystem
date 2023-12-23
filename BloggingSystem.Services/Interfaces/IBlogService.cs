using BloggingSystem.Domain.Models;

namespace BloggingSystem.Services.Interfaces;

public interface IBlogService
{
    public Task<IEnumerable<Blog>> GetAllBlogs();
    
    public Task<Blog> GetBlogById(string id);
    
    public IEnumerable<Blog> GetBlogsByUserId(string id);
    
    public Task CreateBlog(Blog blog);
    
    public Task UpdateBlog(Blog blog);
    
    public Task DeleteBlog(string id);
}