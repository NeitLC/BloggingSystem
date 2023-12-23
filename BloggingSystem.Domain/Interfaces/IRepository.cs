using System.Linq.Expressions;
using BloggingSystem.Domain.Models;

namespace BloggingSystem.Domain.Interfaces;

public interface IRepository <T> where T : BaseEntity
{
    void Update(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T> GetByIdAsync(string id, params Expression<Func<T, object>>[] includes);
    Task AddAsync(T entity);

    IEnumerable<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);
}