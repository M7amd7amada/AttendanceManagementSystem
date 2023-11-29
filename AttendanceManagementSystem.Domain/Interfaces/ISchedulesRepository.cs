namespace AttendanceManagementSystem.Domain.Interfaces;

public interface ISchedulesRepository : IRepositoryBase<Schedule>
{
    public int WorkingHoursCount { get; }
    public int WorkingDaysCount { get; }

    public Task<IEnumerable<Guid>> GetUsers(Guid scheduleId);
}