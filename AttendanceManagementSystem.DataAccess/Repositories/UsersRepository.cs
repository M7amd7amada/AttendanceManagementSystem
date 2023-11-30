
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class UsersRepository : RepositoryBase<User>,
        IUsersRepository
{
    private readonly IAttendancesRepository _attendances;

    public UsersRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
        _attendances = _unitOfWork.Attendances;
    }

    public async Task CreateUser(User user, Guid scheduleId)
    {
        user.ScheduleId = scheduleId;
        await AddAsync(user);
    }

    public async Task AssignAttendanceAsync(Guid userId, Guid attendanceId)
    {
        var user = await GetByIdAsync(userId);
        ArgumentNullException.ThrowIfNull(user);

        var attendance = await _attendances.GetByIdAsync(attendanceId);
        ArgumentNullException.ThrowIfNull(attendance);

        (user.Attendances
            ?? Enumerable.Empty<Attendance>()).ToList().Add(attendance);
    }

    public Task GenerateReport(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Attendance>> GetAttendancesAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        ArgumentNullException.ThrowIfNull(user);

        return (user.Attendances
            ?? Enumerable.Empty<Attendance>()).OrderByDescending(a => a.CreatedDate).ToList();
    }

    public async Task<Attendance> GetCurrentAttendance(Guid userId)
    {
        var attendances = await GetAttendancesAsync(userId);
        var lastAttendance = attendances.FirstOrDefault();

        ArgumentNullException.ThrowIfNull(lastAttendance);

        return lastAttendance;
    }

    public Task<Payroll> GetLastPayroll(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payroll>> GetPayrolls(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Report>> GetReports(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Schedule> GetSchedule(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task ProvideLeaveRequest(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SubscribeToPayroll(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task SubscribeToSchedule(Guid userId, Guid scheduleId)
    {
        var user = await GetByIdAsync(userId);

        ArgumentNullException.ThrowIfNull(user);

        user.ScheduleId = scheduleId;
    }
}