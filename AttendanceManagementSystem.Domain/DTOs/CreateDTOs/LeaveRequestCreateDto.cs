using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record LeaveRequestCreateDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public LeaveType LeaveType { get; set; }

    [Required]
    public LeaveStatus LeaveStatus { get; set; }

    [Required]
    public DateTime LeaveStartDate { get; set; }

    [Required]
    public DateTime LeaveEndDate { get; set; }
}