
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class RefreshTokensRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<RefreshToken>(context, logger),
        IRefreshTokensRepository
{
}