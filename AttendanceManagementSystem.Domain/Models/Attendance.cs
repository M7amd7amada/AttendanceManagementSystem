using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class Attendance : EntityBase
{
    public DaysOfWeek DayOfWeek { get; set; }
    public DateTime AttendanceTime { get; set; }
    public DateTime DepartureTime { get; set; }

    // Relationships
    public Guid UserId { get; set; }
    public ICollection<AttendanceReport>? AttendanceReports { get; set; }
}