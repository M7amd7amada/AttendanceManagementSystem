
using AttendanceManagementSystem.Domain.Models.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class SchedulesRepository : RepositoryBase<Schedule>,
        ISchedulesRepository
{
    public SchedulesRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public async Task<int> GetWorkingHoursCountAsync(Guid id)
    {
        var schedule = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(schedule);

        var result = (schedule.EndTime - schedule.StartTime).Hours;
        return result;
    }
    public async Task<int> GetWorkingDaysCountAsync(Guid id)
    {
        var schedule = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(schedule);

        var result = (schedule.WorkDays
            ?? Enumerable.Empty<DaysOfWeek>()).Count();
        return result;
    }
}