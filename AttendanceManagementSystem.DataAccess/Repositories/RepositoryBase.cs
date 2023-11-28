using System.Linq.Expressions;

using AttendanceManagementSystem.DataAccess.Data;
using AttendanceManagementSystem.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RepositoryBase<T>(AppDbContext context) : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context = context;

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

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
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