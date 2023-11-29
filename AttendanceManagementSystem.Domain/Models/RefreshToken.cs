using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace AttendanceManagementSystem.Domain.Models;

public class RefreshToken : EntityBase
{
    public string? UserId { get; set; }
    public string JwtId { get; set; } = default!;
    public string Token { get; set; } = default!;
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime ExpiryDate { get; set; }

    [ForeignKey(nameof(UserId))]
    public IdentityUser? User { get; set; }
}