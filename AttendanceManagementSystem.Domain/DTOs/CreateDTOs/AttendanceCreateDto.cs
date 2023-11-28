using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record AttendanceCreateDto
{
    public DaysOfWeek DayOfWeek { get; set; }
    public TimeOnly AttendanceTime { get; set; }
    public TimeOnly DepartureTime { get; set; }
}