namespace BloggingSystem.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IBlogRepository Blogs { get; }
    
    public IPostRepository Posts { get; }
    
    // public ICommentRepository Comments { get; }
    
    Task CommitAsync();
}