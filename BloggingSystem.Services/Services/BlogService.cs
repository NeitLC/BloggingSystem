using System.Reflection.Metadata;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Models;
using BloggingSystem.Services.Exceptions;
using BloggingSystem.Services.Interfaces;

namespace BloggingSystem.Services.Services;

public class BlogService : IBlogService
{
    private readonly IUnitOfWork _unitOfWork;

    public BlogService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        return await _unitOfWork.Blogs.GetAllAsync(blog => blog.User!, blog => blog.Posts!);
    }

    public async Task<Blog> GetBlogById(string id)
    {
        var blog = await _unitOfWork.Blogs.GetByIdAsync(
            id,
            blog => blog.User,
            blog => blog.Posts);
        if (blog == null)
        {
            throw new BlogNotFoundException($"Blog with Id = {id} not found!");
        }

        return blog;
    }

    public IEnumerable<Blog> GetBlogsByUserId(string id)
    {
        var blogs = _unitOfWork.Blogs.Find(
            blog => blog.UserId == id,
            blog => blog.User,
            blog => blog.Posts);
        
        if (blogs == null)
        {
            throw new BlogNotFoundException($"User with UserID = {id} doesn't have any blogs!");
        }

        return blogs;
    }

    public async Task CreateBlog(Blog blog)
    {
        blog.Id = Guid.NewGuid().ToString();
        await _unitOfWork.Blogs.AddAsync(blog);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateBlog(Blog blog)
    {
        _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteBlog(string id)
    {
        var blogToDelete = await GetBlogById(id);
        _unitOfWork.Blogs.Delete(blogToDelete);
        await _unitOfWork.CommitAsync();
    }
}