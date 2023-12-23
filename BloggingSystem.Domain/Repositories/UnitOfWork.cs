using BloggingSystem.Domain.Context;
using BloggingSystem.Domain.Interfaces;

namespace BloggingSystem.Domain.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;
    public IBlogRepository Blogs { get; }
    public IPostRepository Posts { get; }
    // public ICommentRepository Comments { get; }
    
    public UnitOfWork(
        ApplicationDbContext applicationDbContext,
        IBlogRepository blogs,
        IPostRepository posts
        // ICommentRepository comments
        )
    {
        _applicationDbContext = applicationDbContext;
        Blogs = blogs;
        Posts = posts;
        // Comments = comments;
    }

    public async Task CommitAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _applicationDbContext.Dispose();
        }
    }
}