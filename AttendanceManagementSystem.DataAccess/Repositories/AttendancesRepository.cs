
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class AttendancesRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<Attendance>(context, logger),
        IAttendancesRepository
{
    public int WorkingHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}