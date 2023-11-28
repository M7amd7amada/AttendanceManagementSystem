namespace AttendanceManagementSystem.DataAccess.Repositories;

public class SchedulesRepository(AppDbContext context)
    : RepositoryBase<Schedule>(context),
        ISchedulesRepository
{
}