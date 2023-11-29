using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record ReportCreateDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public DateTime ReportDate { get; set; }

    [Required]
    public ReportType ReportType { get; set; }

    [Required]
    public required string ReportDetails { get; set; }
}