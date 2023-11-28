using System.Linq.Expressions;

using AttendanceManagementSystem.Domain.Consts;

namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    public Task<T> GetByIdAsync(Guid id);

    public Task<IEnumerable<T>> GetAllAsync();

    public Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null!);

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        string[] includes = null!);

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int skip,
        int take);

    public Task<IEnumerable<T>> FindAllAsync(
        Expression<Func<T, bool>> criteria,
        int? skip,
        int? take,
        Expression<Func<T, object>> orderBy = null!,
        string orderByDirection = OrderBy.Ascending);

    public Task<bool> AddAsync(T entity);

    public Task<bool> AddRangeAsync(IEnumerable<T> entities);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(T entity);
    public Task<bool> DeleteRange(IEnumerable<T> entities);
    public void Attach(T entity);
    public void AttachRange(IEnumerable<T> entities);
    public Task<int> CountAsync();
    public Task<int> CountAsync(Expression<Func<T, bool>> criteria);

}