namespace AttendanceManagementSystem.Domain.Interfaces;

public interface ILeaveRequestsRepostiory : IRepositoryBase<LeaveRequest>
{
    public int LeaveRequestsCount { get; }
    public Task<Guid> GetUserById(Guid id);
}