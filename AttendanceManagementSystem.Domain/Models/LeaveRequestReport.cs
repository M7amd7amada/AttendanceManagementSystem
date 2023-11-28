namespace AttendanceManagementSystem.Domain.Models;

public class LeaveRequestReport
{
    public Guid LeaveRequestId { get; set; }
    public Guid ReportId { get; set; }

    public Report Report { get; set; } = null!;
    public LeaveRequest LeaveRequest { get; set; } = null!;
}