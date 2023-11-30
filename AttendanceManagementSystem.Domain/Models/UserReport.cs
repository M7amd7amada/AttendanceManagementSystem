namespace AttendanceManagementSystem.Domain.Models;

public class UserReport
{
    public User User { get; set; } = null!;
    public Report Report { get; set; } = null!;
    public Guid UserId { get; set; }
    public Guid ReportId { get; set; }
}