
namespace AttendanceManagementSystem.DataAccess.Repositories;

public class LeaveRequestsRepository(AppDbContext context)
    : RepositoryBase<LeaveRequest>(context),
        ILeaveRequestsRepostiory
{
    public int LeaveRequestsCount => throw new NotImplementedException();

    public Task<Guid> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }
}