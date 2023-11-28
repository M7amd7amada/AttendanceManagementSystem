namespace AttendanceManagementSystem.Domain.DTOs.CreateDTOs;

public record UserCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}