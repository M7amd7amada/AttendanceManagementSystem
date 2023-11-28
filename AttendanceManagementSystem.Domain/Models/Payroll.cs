using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Domain.Models;

public class Payroll : EntityBase
{
    public DateOnly PayPeriodStart { get; set; }
    public DateOnly PayPerionEnd { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal BaseSalary { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal TotalPay { get; set; }

    // Relationships
    public Guid User { get; set; }
    public ICollection<PayrollReport>? PayrollReports { get; set; }
}