
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class UsersRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<User>(context, logger),
        IUsersRepository
{
    public Task AssignAttendance(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task GenerateReport(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Attendance>> GetAttendances(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Attendance> GetCurrentAttendance(Guid id)
    {
        throw new NotImplementedException();
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

    public Task SubscribeToSchedule(Guid id)
    {
        throw new NotImplementedException();
    }
}