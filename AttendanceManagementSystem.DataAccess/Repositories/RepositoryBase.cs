using System.Linq.Expressions;

using AttendanceManagementSystem.Domain.Consts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ILogger _logger;
    protected readonly DbSet<T> _entities;
    public RepositoryBase(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork)
    {
        _context = context;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _entities = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {

        await _entities.AddRangeAsync(entities);
    }

    public void Attach(T entity)
    {
        _entities.Attach(entity);
    }

    public void AttachRange(IEnumerable<T> entities)
    {
        _entities.AttachRange(entities);
    }

    public async Task<int> CountAsync()
    {
        return await _entities.CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
    {
        return await _entities.CountAsync(criteria);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _entities.RemoveRange(entities);
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
        return await _context.Set<T>()
            .Where(criteria)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
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

    public async Task<T?> FindAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var incluse in includes)
                query = query.Include(incluse);

        return await query.SingleOrDefaultAsync(criteria);
    }

    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _entities.AnyAsync(e => GetEntityId(e) == id);
    }

    public async Task UpsertAsync(T entity)
    {
        if (await ExistsAsync(GetEntityId(entity)))
            Update(entity);
        await AddAsync(entity);
    }

    private Guid GetEntityId(T entity)
    {
        return (Guid)entity.GetType().GetProperty("Id")!.GetValue(entity)!;
    }
}