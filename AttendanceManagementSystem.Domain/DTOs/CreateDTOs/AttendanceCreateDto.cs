using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record AttendanceCreateDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public DaysOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeOnly AttendanceTime { get; set; }

    [Required]
    public TimeOnly DepartureTime { get; set; }
}