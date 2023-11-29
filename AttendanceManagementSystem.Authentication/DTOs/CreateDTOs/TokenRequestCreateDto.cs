using System.ComponentModel.DataAnnotations;

namespace AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;

public class TokenRequestCreateDto
{
    [Required]
    public required string Token { get; set; }

    [Required]
    public required string RefreshToken { get; set; }
}