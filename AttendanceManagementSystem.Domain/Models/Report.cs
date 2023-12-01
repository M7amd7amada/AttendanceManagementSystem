using System.ComponentModel.DataAnnotations;

using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class Report : EntityBase
{
    public DateTime ReportDate { get; set; }
    public ReportType ReportType { get; set; }
    public string? ReportDetails { get; set; }

    // Relationships
    public ICollection<UserReport>? UserReports { get; set; }
    public ICollection<LeaveRequestReport>? LeaveRequestReports { get; set; }
    public ICollection<AttendanceReport>? AttendanceReports { get; set; }
    public ICollection<PayrollReport>? PayrollReports { get; set; }
}