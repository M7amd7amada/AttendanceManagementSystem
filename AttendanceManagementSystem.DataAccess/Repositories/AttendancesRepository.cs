
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class AttendancesRepository : RepositoryBase<Attendance>,
        IAttendancesRepository
{
    public AttendancesRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public int WorkingHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}