namespace AttendanceManagementSystem.Authentication.DTOs.ReadDTOs;

public record UserRegistrationResponseReadDto : AuthResultReadDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}