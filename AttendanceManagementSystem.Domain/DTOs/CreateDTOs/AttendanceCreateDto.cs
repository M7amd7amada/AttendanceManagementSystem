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
    public DateTime AttendanceTime { get; set; }

    [Required]
    public DateTime DepartureTime { get; set; }
}