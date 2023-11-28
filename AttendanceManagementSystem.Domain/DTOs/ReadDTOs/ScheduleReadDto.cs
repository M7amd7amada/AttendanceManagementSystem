using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public class ScheduleReadDto
{
    public List<DaysOfWeek>? WorkingDays { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public TimeSpan WorkingHours => EndTime - StartTime;
    public int WorkingDaysCount => (WorkingDays ?? Enumerable.Empty<DaysOfWeek>()).Count();
}