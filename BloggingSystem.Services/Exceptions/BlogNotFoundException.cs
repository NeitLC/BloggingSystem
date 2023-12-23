namespace BloggingSystem.Services.Exceptions;

public class BlogNotFoundException : Exception
{
    public BlogNotFoundException(string? message) : base(message)
    {
        
    }
}