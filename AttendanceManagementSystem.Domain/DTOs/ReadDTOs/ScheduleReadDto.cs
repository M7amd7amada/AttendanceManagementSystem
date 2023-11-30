using AttendanceManagementSystem.Domain.Interfaces;
using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record ScheduleReadDto
{
    public Guid Id { get; set; }
    public List<DaysOfWeek>? WorkDays { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}