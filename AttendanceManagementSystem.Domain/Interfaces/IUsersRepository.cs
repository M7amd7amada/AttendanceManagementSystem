namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IUsersRepository : IRepositoryBase<User>
{
    public Task<Schedule> GetSchedule(Guid id);
    public Task<IEnumerable<Attendance>> GetAttendances(Guid id);
    public Task<IEnumerable<Payroll>> GetPayrolls(Guid id);
    public Task<IEnumerable<Report>> GetReports(Guid id);
    public Task<Attendance> GetCurrentAttendance(Guid id);
    public Task<Payroll> GetLastPayroll(Guid id);
    public Task GenerateReport(Guid id);
    public Task SubscribeToSchedule(Guid id);
    public Task SubscribeToPayroll(Guid id);
    public Task AssignAttendance(Guid id);
    public Task ProvideLeaveRequest(Guid id);
}