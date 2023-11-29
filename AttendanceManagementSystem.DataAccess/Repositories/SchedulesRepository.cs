
using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class SchedulesRepository(AppDbContext context)
    : RepositoryBase<Schedule>(context),
        ISchedulesRepository
{
    private readonly DbSet<Schedule> _schedules = context.Schedules;
    private readonly DbSet<User> _users = context.Users;

    public int WorkingHoursCount => throw new NotImplementedException();

    public int WorkingDaysCount => throw new NotImplementedException();

    public async Task<IEnumerable<Guid>> GetUsers(Guid scheduleId)
    {
        return await _users
            .Where(user => user.Id == scheduleId)
            .Select(user => user.Id)
            .ToListAsync();
    }
}