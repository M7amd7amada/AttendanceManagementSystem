namespace AttendanceManagementSystem.Domain.Models;

public class AttendanceReport
{
    public Guid AttendanceId { get; set; }
    public Guid ReportId { get; set; }
    public Attendance Attendance { get; set; } = null!;
    public Report Report { get; set; } = null!;
}