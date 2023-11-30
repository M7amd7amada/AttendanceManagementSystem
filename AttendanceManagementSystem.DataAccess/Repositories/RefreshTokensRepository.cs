
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RefreshTokensRepository : RepositoryBase<RefreshToken>,
        IRefreshTokensRepository
{
    public RefreshTokensRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public async Task<RefreshToken> GetByRefreshTokenAsync(string refreshToken)
    {
        try
        {
            var res = await _entities.Where(x => x.Token == refreshToken)
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
            var token = await _entities.Where(x => x.Token == refreshToken.Token)
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