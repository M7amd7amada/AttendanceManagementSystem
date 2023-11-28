namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record UserReadDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}