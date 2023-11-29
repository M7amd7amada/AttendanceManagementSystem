using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record AttendanceReadDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DaysOfWeek DaysOfWeek { get; set; }
    public TimeOnly AttendanceTime { get; set; }
    public TimeOnly DepartureTime { get; set; }
}