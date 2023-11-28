using System.Dynamic;
using System.Linq.Expressions;

using AttendanceManagementSystem.DataAccess.Data;
using AttendanceManagementSystem.Domain.Consts;
using AttendanceManagementSystem.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _data;
    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _data = _context.Set<T>();
    }

    private async Task<bool> Complete() => await _context.SaveChangesAsync() > 0;

    public async Task<bool> AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _data.AddAsync(entity);
        return await Complete();
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        await _data.AddRangeAsync(entities);
        return await Complete();
    }

    public void Attach(T entity)
    {
        _data.Attach(entity);
    }

    public void AttachRange(IEnumerable<T> entities)
    {
        _data.AttachRange(entities);
    }

    public async Task<int> CountAsync()
    {
        return await _data.CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
    {
        return await _data.CountAsync(criteria);
    }

    public async Task<bool> Delete(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _data.Remove(entity);
        return await Complete();
    }

    public async Task<bool> DeleteRange(IEnumerable<T> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        _data.RemoveRange(entities);
        return await Complete();
    }

    public async Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(criteria).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int skip,
        int take)
    {
        return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int? skip,
        int? take,
        Expression<Func<T, object>> orderBy = null!,
        string orderByDirection = OrderBy.Ascending)
    {
        IQueryable<T> query = _context.Set<T>().Where(criteria);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (orderBy != null)
        {
            query = orderByDirection == OrderBy.Ascending
                ? query.OrderBy(orderBy)
                : (IQueryable<T>)query.OrderByDescending(orderBy);
        }
        return await query.ToListAsync();
    }

    public async Task<T> FindAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var incluse in includes)
                query = query.Include(incluse);

        return await query.SingleOrDefaultAsync(criteria)
                    ?? throw new ArgumentNullException(nameof(criteria));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _data.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _data.FindAsync(id)
            ?? throw new ArgumentNullException();
    }

    public async Task<bool> Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        _data.Update(entity);
        return await Complete();
    }
}