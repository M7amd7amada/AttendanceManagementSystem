
using Microsoft.Extensions.Logging;

namespace AttendanceManagementSystem.DataAccess.Repositories;

public class PayrollsRepository : RepositoryBase<Payroll>,
        IPayrollsRepository
{
    public PayrollsRepository(
        AppDbContext context,
        ILogger logger,
        IUnitOfWork unitOfWork) : base(context, logger, unitOfWork)
    {
    }

    public decimal TotalExpenses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public Task<IEnumerable<Guid>> GetUsers()
    {
        throw new NotImplementedException();
    }
}