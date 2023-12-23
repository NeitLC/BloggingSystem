using System.Linq.Expressions;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Models;
using BloggingSystem.Services.Exceptions;
using BloggingSystem.Services.Interfaces;

namespace BloggingSystem.Services.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;

    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {  
        return await _unitOfWork.Posts.GetAllAsync(
            post => post.Blog!,
            post => post.User!);
    }

    public async Task<Post> GetPostById(string id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(
            id,
            post => post.Blog!,
            post => post.User!
        );
        
        if (post == null)
        {
            throw new PostNotFoundException($"Post with ID = {id} was not found!");
        }
        return post;
    }

    public IEnumerable<Post> GetPostsByUserId(string id)
    {
        var post = _unitOfWork.Posts.Find(
            post => post.UserId == id,
            post => post.Blog!,
            post => post.User!
        );
        
        if (post == null)
        {
            throw new PostNotFoundException($"User with UserID = {id} doesn't have any posts!");
        }
        return post;
    }

    public IEnumerable<Post> GetPostsByBlogId(string id)
    {
        var post = _unitOfWork.Posts.Find(
            post => post.BlogId == id,
            post => post.Blog!,
            post => post.User!
        );
        if (post == null)
        {
            throw new PostNotFoundException($"Blog with BlogID = {id} doesn't have any posts!");
        }
        return post;
    }

    public async Task CreatePost(Post post)
    {
        post.Id = Guid.NewGuid().ToString();
        await _unitOfWork.Posts.AddAsync(post);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdatePost(Post post)
    {
        _unitOfWork.Posts.Update(post);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeletePost(string id)
    {
        var post = await GetPostById(id);
        _unitOfWork.Posts.Delete(post);
        await _unitOfWork.CommitAsync();
    }
}