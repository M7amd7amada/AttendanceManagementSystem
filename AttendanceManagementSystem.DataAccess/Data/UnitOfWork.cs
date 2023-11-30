using AttendanceManagementSystem.DataAccess.Repositories;

using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ILogger _logger;
    public UnitOfWork(
        AppDbContext context,
        ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("db_logs");

        Users = new UsersRepository(_context, _logger, this);
        Schedules = new SchedulesRepository(_context, _logger, this);
        Reports = new ReportsRepository(_context, _logger, this);
        Payrolls = new PayrollsRepository(_context, _logger, this);
        LeaveRequests = new LeaveRequestsRepository(_context, _logger, this);
        Attendances = new AttendancesRepository(_context, _logger, this);
        RefreshTokens = new RefreshTokensRepository(_context, _logger, this);
    }

    public IUsersRepository Users { get; private set; }
    public ISchedulesRepository Schedules { get; private set; }
    public IReportsRepository Reports { get; private set; }
    public IPayrollsRepository Payrolls { get; private set; }
    public ILeaveRequestsRepostiory LeaveRequests { get; private set; }
    public IAttendancesRepository Attendances { get; private set; }
    public IRefreshTokensRepository RefreshTokens { get; private set; }

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose() => _context.Dispose();
}