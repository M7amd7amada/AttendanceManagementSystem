using static AttendanceManagementSystem.Domain.Models.Enums.DaysOfWeek;
using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class Schedule : EntityBase
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<DaysOfWeek>? WorkDays { get; set; }

    // Relationships
    public ICollection<User>? Users { get; set; }
}
