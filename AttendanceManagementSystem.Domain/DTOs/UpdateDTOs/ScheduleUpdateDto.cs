using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.UpdateDTOs;

public class ScheduleUpdateDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public List<DaysOfWeek>? WorkDays { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime Endtime { get; set; }

}