namespace AttendanceManagementSystem.Domain.Interfaces;

public interface ISchedulesRepository : IRepositoryBase<Schedule>
{
    public Task<int> GetWorkingHoursCount(Guid id);
    public Task<int> GetWorkingDaysCount(Guid id);
}