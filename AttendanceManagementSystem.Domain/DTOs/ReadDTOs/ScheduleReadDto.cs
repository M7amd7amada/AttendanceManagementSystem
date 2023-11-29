using AttendanceManagementSystem.Domain.Interfaces;
using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record ScheduleReadDto
{
    public Guid Id { get; set; }
    public List<DaysOfWeek>? WorkingDays { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}