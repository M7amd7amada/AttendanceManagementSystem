namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IUsersRepository : IRepositoryBase<User>
{
    public Task CreateUser(User user, Guid scheduleId);
    public Task<Schedule> GetSchedule(Guid id);
    public Task<IEnumerable<Attendance>> GetAttendancesAsync(Guid userId);
    public Task<IEnumerable<Payroll>> GetPayrolls(Guid id);
    public Task<IEnumerable<Report>> GetReports(Guid id);
    public Task<Attendance> GetCurrentAttendance(Guid id);
    public Task<Payroll> GetLastPayroll(Guid id);
    public Task GenerateReport(Guid id);
    public Task SubscribeToSchedule(Guid userId, Guid scheduleId);
    public Task SubscribeToPayroll(Guid id);
    public Task AssignAttendanceAsync(Guid userId, Guid attendanceId);
    public Task ProvideLeaveRequest(Guid id);
}