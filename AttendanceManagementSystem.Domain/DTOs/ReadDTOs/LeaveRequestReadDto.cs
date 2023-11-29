using AttendanceManagementSystem.Domain.Models.Enums;

namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record LeaveRequestReadDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public LeaveType LeaveType { get; set; }
    public LeaveStatus LeaveStatus { get; set; }
    public DateTime LeaveStartDate { get; set; }
    public DateTime LeaveEndDate { get; set; }
    public int LeavingDays => (LeaveEndDate - LeaveStartDate).Days;
}