
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RefreshTokensRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<RefreshToken>(context, logger),
        IRefreshTokensRepository
{
    public async Task<RefreshToken> GetByRefreshTokenAsync(string refreshToken)
    {
        try
        {
            var res = await _data.Where(x => x.Token.Equals(
                    refreshToken,
                    StringComparison.CurrentCultureIgnoreCase))
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return res ?? throw new ArgumentNullException();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "{Repo} {Method} has generated an error",
                typeof(RefreshTokensRepository),
                nameof(GetByRefreshTokenAsync));
            return null!;
        }
    }

    public async Task<bool> MarkRefreshTokenAsUsedAsync(RefreshToken refreshToken)
    {
        try
        {
            var token = await _data.Where(x => x.Token.Equals(
                    refreshToken.Token,
                    StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefaultAsync();

            if (token is null) return false;
            token.IsUsed = refreshToken.IsUsed;
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "{Repo} {Method} has generated an error",
                typeof(RefreshTokensRepository),
                nameof(MarkRefreshTokenAsUsedAsync));
            return false;
        }
    }
}