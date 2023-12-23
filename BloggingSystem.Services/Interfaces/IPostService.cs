using BloggingSystem.Domain.Models;

namespace BloggingSystem.Services.Interfaces;

public interface IPostService
{
    public Task<IEnumerable<Post>> GetAllPosts();

    public Task<Post> GetPostById(string id);

    public IEnumerable<Post> GetPostsByUserId(string id);

    public IEnumerable<Post> GetPostsByBlogId(string id);

    public Task CreatePost(Post post);

    public Task UpdatePost(Post post);

    public Task DeletePost(string id);
}