namespace AttendanceManagementSystem.Authentication.DTOs.ReadDTOs;

public record AuthResultReadDto
{
    public List<string>? Errors { get; set; }
    public string? Token { get; set; }
    public bool Success { get; set; }
}