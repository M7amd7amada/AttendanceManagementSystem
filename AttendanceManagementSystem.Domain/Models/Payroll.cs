using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Domain.Models;

public class Payroll : EntityBase
{
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPerionEnd { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal BaseSalary { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public decimal TotalPay { get; set; }

    // Relationships
    public Guid User { get; set; }
    public ICollection<PayrollReport>? PayrollReports { get; set; }
}