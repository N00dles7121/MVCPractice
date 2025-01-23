using System;
using System.Linq.Expressions;

namespace MVCPractice.Data.Repositories.Repo;

public interface IRepo<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(Expression<Func<T, bool>> filter);
    Task<T> GetById(int id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task DeleteRange(IEnumerable<T> entities);
}
