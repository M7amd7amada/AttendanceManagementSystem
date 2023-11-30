namespace AttendanceManagementSystem.Domain.Interfaces;

public interface IRefreshTokensRepository : IRepositoryBase<RefreshToken>
{
    public Task<RefreshToken> GetByRefreshTokenAsync(string refreshToken);
    public Task<bool> MarkRefreshTokenAsUsedAsync(RefreshToken refreshToken);
}