using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record PayrollCreateDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public DateTime PayPeriodStart { get; set; }

    [Required]
    public DateTime PayPeriodEnd { get; set; }

    [Required]
    [Column(TypeName = "decimal(7, 2)")]
    public decimal BaseSalary { get; set; }
}