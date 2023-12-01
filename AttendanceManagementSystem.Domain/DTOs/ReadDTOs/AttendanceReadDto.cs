using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record AttendanceReadDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DaysOfWeek DayOfWeek { get; set; }
    public DateTime AttendanceTime { get; set; }
    public DateTime DepartureTime { get; set; }
}