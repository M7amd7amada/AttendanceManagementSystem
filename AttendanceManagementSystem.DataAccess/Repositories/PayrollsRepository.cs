
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class PayrollsRepository(AppDbContext context, ILogger logger)
    : RepositoryBase<Payroll>(context, logger),
        IPayrollsRepository
{
    public decimal TotalExpenses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetUsers()
    {
        throw new NotImplementedException();
    }
}