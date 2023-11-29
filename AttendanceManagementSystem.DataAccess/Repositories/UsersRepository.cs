
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