using System.ComponentModel.DataAnnotations;

namespace AttendanceManagementSystem.Domain.Models;

public class User : EntityBase
{
    public Guid IdentityId { get; set; }

    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [Required]
    [StringLength(50)]
    public required string Phone { get; set; }


    // Relationships
    public Schedule Schedule { get; set; } = null!;
    public ICollection<Attendance>? Attendances { get; set; }
    public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    public ICollection<Payroll>? Payrolls { get; set; }
    public ICollection<Report>? Reports { get; set; }
}