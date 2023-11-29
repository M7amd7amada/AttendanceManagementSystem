
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class ReportsRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<Report>(context, logger),
        IReportsRepository
{
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