using AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

namespace AttendanceManagementSystem.UI.Services.Contracts;

public interface IScheduleService
{
    public Task CreateSchedule();
    public Task<IEnumerable<ScheduleReadDto>> GetSchedulesAsync();
}