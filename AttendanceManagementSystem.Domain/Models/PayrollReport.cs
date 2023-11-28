namespace AttendanceManagementSystem.Domain.Models;

public class PayrollReport
{
    public Guid PayrollId { get; set; }
    public Guid ReportId { get; set; }
    public Payroll Payroll { get; set; } = null!;
    public Report Report { get; set; } = null!;
}