
using AttendanceManagementSystem.Domain.Models.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class SchedulesRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<Schedule>(context, logger),
        ISchedulesRepository
{
    public async Task<int> GetWorkingHoursCount(Guid id)
    {
        var schedule = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(schedule);

        var result = (schedule.EndTime - schedule.StartTime).Hours;
        return result;
    }
    public async Task<int> GetWorkingDaysCount(Guid id)
    {
        var schedule = await GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(schedule);

        var result = (schedule.WorkDays
            ?? Enumerable.Empty<DaysOfWeek>()).Count();
        return result;
    }
}