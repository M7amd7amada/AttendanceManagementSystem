using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record ScheduleCreateDto
{
    [Required]
    public List<DaysOfWeek>? WorkDays { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime Endtime { get; set; }
}