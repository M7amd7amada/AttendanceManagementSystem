namespace AttendanceManagementSystem.Domain.DTOs.ReadDTOs;

public record UserReadDto
{
    public Guid Id { get; set; }
    public Guid IdentityId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}