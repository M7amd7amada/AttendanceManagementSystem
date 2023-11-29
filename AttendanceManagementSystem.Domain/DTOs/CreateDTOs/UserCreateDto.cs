using System.ComponentModel.DataAnnotations;

namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record UserCreateDto
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Phone { get; set; }
}