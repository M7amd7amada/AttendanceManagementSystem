namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record PayrollReadDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime PayPeriodStart { get; set; }
    public DateTime PayPeriodEnd { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal TotalPay { get; set; }
}