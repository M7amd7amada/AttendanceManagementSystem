using System.Linq.Expressions;

using AttendanceManagementSystem.Domain.Interfaces;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public Task<bool> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public Task Attach(T entity)
    {
        throw new NotImplementedException();
    }

    public Task AttachRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int skip,
        int take)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int? skip,
        int? take,
        Expression<Func<T, object>> orderBy = null!,
        string orderByDirection = "ASC")
    {
        throw new NotImplementedException();
    }

    public Task<T> FindAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
}