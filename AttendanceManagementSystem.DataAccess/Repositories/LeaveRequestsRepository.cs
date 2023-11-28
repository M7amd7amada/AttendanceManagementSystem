namespace AttendanceManagementSystem.DataAccess.Repositories;

public class LeaveRequestsRepository(AppDbContext context)
    : RepositoryBase<LeaveRequest>(context),
        ILeaveRequestsRepostiory
{
}