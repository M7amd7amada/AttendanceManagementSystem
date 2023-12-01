
using AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

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

    public int WorkingHours => throw new NotImplementedException();

    public async Task CreateAttendance(Attendance attendance, Guid userId)
    {
        attendance.UserId = userId;
        await AddAsync(attendance);
    }

    public Task<IEnumerable<Guid>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}