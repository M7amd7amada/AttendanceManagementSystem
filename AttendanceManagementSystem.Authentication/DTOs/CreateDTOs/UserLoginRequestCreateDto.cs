using System.ComponentModel.DataAnnotations;

namespace AttendanceManagementSystem.Authentication.DTOs.CreateDTOs;

public class UserLoginRequestCreateDto
{
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}