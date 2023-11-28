using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.Models;

public class LeaveRequest : EntityBase
{
    public LeaveType LeaveType { get; set; }
    public DateTime LeaveStartDate { get; set; }
    public DateTime? LeaveEndDate { get; set; }
    public LeaveStatus LeaveStatus { get; set; }

    // Relationships
    public Guid User { get; set; }
    public ICollection<LeaveRequestReport>? LeaveRequestReports { get; set; }
}