using static AttendanceManagementSystem.Domain.Models.Enums.DaysOfWeek;
using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class Schedule : EntityBase
{
    public Schedule()
    {
        WorkDays = [Sunday, Monday, Tuesday, Wednesday, Thursday];
        StartTime = TimeOnly.Parse("09:00");
        EndTime = TimeOnly.Parse("17:00");
    }

    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public List<DaysOfWeek> WorkDays { get; set; }

    // Relationships
    public Guid UserId { get; set; }
}
