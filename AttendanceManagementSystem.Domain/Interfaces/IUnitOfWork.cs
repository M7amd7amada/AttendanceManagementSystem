namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUsersRepository Users { get; }
    public bool Complete();
}