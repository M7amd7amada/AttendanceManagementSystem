namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record PayrollReadDto
{
    public Guid Id { get; set; }
    public DateOnly PayPeriodStart { get; set; }
    public DateOnly PayPeriodEnd { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal TotalPay { get; set; }
}