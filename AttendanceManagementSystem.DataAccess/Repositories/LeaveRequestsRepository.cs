
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class LeaveRequestsRepository : RepositoryBase<LeaveRequest>,
        ILeaveRequestsRepostiory
{
    public LeaveRequestsRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public int LeaveRequestsCount => throw new NotImplementedException();

    public Task<Guid> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }
}