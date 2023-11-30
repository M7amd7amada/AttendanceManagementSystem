namespace AttendanceManagementSystem.Domain.Interfaces;

public interface ISchedulesRepository : IRepositoryBase<Schedule>
{
    public Task<int> GetWorkingHoursCountAsync(Guid id);
    public Task<int> GetWorkingDaysCountAsync(Guid id);
}