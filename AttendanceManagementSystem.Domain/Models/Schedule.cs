using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class Schedule : EntityBase
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public IEnumerable<DaysOfWeek>? WorkDays { get; set; }

    // Relationships
    public Guid UserId { get; set; }
}
