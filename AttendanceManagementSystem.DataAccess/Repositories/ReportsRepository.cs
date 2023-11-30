
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class ReportsRepository : RepositoryBase<Report>,
        IReportsRepository
{
    public ReportsRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public Task CreateReport(User user, Guid scheduleId)
    {
        throw new NotImplementedException();
    }

    public Task GenerateAttendancesReport()
    {
        throw new NotImplementedException();
    }

    public Task GenerateLeaveRequestsReport()
    {
        throw new NotImplementedException();
    }

    public Task GeneratePayrollsReport()
    {
        throw new NotImplementedException();
    }

    public Task GenerateUserReport(Guid id)
    {
        throw new NotImplementedException();
    }
}