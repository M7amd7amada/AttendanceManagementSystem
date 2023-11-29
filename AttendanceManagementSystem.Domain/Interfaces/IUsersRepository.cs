namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IUsersRepository : IRepositoryBase<User>
{
    public Task SubscribeToSchedule(Guid id);
    public Task SubscribeToPayroll(Guid id);
    public Task AssignAttendance(Guid id);
    public Task ProvideLeaveRequest(Guid id);
}