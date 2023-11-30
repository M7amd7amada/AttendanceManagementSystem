namespace AttendanceManagementSystem.Authentication.DTOs.Generic;

public class TokenDataDto
{
    public string JwtToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}