namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUsersRepository Users { get; }
    public ISchedulesRepository Schedules { get; }
    public IReportsRepository Reports { get; }
    public IPayrollsRepository Payrolls { get; }
    public ILeaveRequestsRepostiory LeaveRequests { get; }
    public IAttendancesRepository Attendances { get; }
    public bool Complete();
}