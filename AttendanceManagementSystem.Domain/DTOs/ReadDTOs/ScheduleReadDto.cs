using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record ScheduleReadDto
{
    public Guid Id { get; set; }
    public List<DaysOfWeek>? WorkingDays { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int WorkingHoursCount => (EndTime - StartTime).Hours;
    public int WorkingDaysCount => (WorkingDays ?? Enumerable.Empty<DaysOfWeek>()).Count();
}