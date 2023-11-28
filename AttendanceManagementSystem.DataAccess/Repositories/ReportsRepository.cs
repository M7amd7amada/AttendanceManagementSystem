namespace AttendanceManagementSystem.DataAccess.Repositories;

public class ReportsRepository(AppDbContext context)
    : RepositoryBase<Report>(context),
        IReportsRepository
{
}