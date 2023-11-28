namespace AttendanceManagementSystem.DataAccess.Repositories;

public class AttendancesRepository(AppDbContext context)
    : RepositoryBase<Attendance>(context),
        IAttendancesRepository
{
}