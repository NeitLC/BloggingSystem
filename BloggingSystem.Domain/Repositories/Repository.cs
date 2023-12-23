using System.Linq.Expressions;
using BloggingSystem.Domain.Context;
using BloggingSystem.Domain.Extension;
using BloggingSystem.Domain.Interfaces;
using BloggingSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingSystem.Domain.Repositories;

public class Repository <T>: IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _applicationDbContext;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void Update(T entity)
    {
        _applicationDbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _applicationDbContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        return await _applicationDbContext.Set<T>().IncludeMultiple(includes).ToListAsync();
    }

    public async Task<T> GetByIdAsync(string id, params Expression<Func<T, object>>[] includes)
    {
        return (await _applicationDbContext.Set<T>().IncludeMultiple(includes).SingleOrDefaultAsync(s => s.Id == id))!;
    }

    public async Task AddAsync(T entity)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity);
    }

    public IEnumerable<T> Find(
        Func<T, bool> predicate, 
        params Expression<Func<T, object>>[] includes)
    {
        return _applicationDbContext.Set<T>()
            .IncludeMultiple(includes).AsEnumerable()
            .Where(predicate)
            .ToList();
    }
}