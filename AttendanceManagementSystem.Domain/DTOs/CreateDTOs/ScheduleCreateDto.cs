using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record ScheduleCreateDto
{
    public List<DaysOfWeek>? WorkDays { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly Endtime { get; set; }
}