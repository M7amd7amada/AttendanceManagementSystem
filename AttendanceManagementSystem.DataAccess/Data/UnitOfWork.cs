using AttendanceManagementSystem.DataAccess.Repositories;
using AttendanceManagementSystem.Domain.Interfaces;

namespace AttendanceManagementSystem.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Users = new UsersRepository(_context);
    }

    public IUsersRepository Users { get; private set; }

    public bool Complete()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose() => _context.Dispose();
}