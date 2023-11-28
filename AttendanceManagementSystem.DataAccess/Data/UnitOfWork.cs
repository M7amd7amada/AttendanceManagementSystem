using AttendanceManagementSystem.DataAccess.Repositories;

namespace AttendanceManagementSystem.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Users = new UsersRepository(_context);
        Schedules = new SchedulesRepository(_context);
        Reports = new ReportsRepository(_context);
        Payrolls = new PayrollsRepository(_context);
        LeaveRequests = new LeaveRequestsRepository(_context);
        Attendances = new AttendancesRepository(_context);
    }

    public IUsersRepository Users { get; private set; }
    public ISchedulesRepository Schedules { get; private set; }
    public IReportsRepository Reports { get; private set; }
    public IPayrollsRepository Payrolls { get; private set; }
    public ILeaveRequestsRepostiory LeaveRequests { get; private set; }
    public IAttendancesRepository Attendances { get; private set; }

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose() => _context.Dispose();
}