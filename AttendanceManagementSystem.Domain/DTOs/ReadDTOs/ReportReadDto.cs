using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record ReportReadDto
{
    public Guid Id { get; set; }
    public DateTime ReportDate { get; set; }
    public ReportType ReportType { get; set; }
    public string? ReportDetails { get; set; }
}