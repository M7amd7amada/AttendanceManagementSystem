
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class LeaveRequestsRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<LeaveRequest>(context, logger),
        ILeaveRequestsRepostiory
{
    public int LeaveRequestsCount => throw new NotImplementedException();

    public Task<Guid> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }
}